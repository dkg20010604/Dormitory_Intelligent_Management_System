using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using SqlSugar.IOC;
using Newtonsoft.Json;
using Model.AutoMapperProfile;
using Static_Class;
using Model.DbModels;
using SqlSugar;
using System.Reflection;
using Microsoft.AspNetCore.SignalR;
using Dormitory_Intelligent_Management_System.SignalR;
using System.IdentityModel.Tokens.Jwt;
using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using Microsoft.AspNetCore.DataProtection;
using NetTaste;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Dormitory_Intelligent_Management_System
{
    /// <summary>
    /// �ֱ���
    /// </summary>
    public class CoustemSplitTables : ISplitTableService
    {
        /// <summary>
        /// �������зֱ�
        /// </summary>
        /// <param name="db"></param>
        /// <param name="EntityInfo"></param>
        /// <param name="tableInfos"></param>
        /// <returns></returns>
        public List<SplitTableInfo> GetAllTables(ISqlSugarClient db, EntityInfo EntityInfo, List<DbTableInfo> tableInfos)
        {
            List<SplitTableInfo> splits = new();
            foreach (var item in tableInfos)
            {
                if (item.Name.Contains("LIVE_INFO_BUILD_"))
                {
                    splits.Add(new SplitTableInfo()
                    {
                        TableName = item.Name //Ҫ��item.name��Ҫд����
                    });
                }
            }
            return splits.OrderBy(it => it.TableName).ToList();
        }

        public object GetFieldValue(ISqlSugarClient db, EntityInfo entityInfo, SplitType splitType, object entityValue)
        {
            var splitColumn = entityInfo.Columns.FirstOrDefault(it => it.PropertyInfo.GetCustomAttribute<SplitFieldAttribute>() != null);
            var value = splitColumn.PropertyInfo.GetValue(entityValue, null);
            return value;
        }
        public string GetTableName(ISqlSugarClient db, EntityInfo EntityInfo)
        {
            return EntityInfo.DbTableName + "01";
        }

        public string GetTableName(ISqlSugarClient db, EntityInfo EntityInfo, SplitType type)
        {
            return EntityInfo.DbTableName + "01";
        }

        public string GetTableName(ISqlSugarClient db, EntityInfo entityInfo, SplitType splitType, object fieldValue)
        {
            int id = (int) fieldValue;
            return entityInfo.DbTableName + (id>9?id.ToString():"0"+ id.ToString());
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IUserIdProvider, UserId>();
            builder.Services.AddSwaggerGen(c =>
            {
                #region Swaggerʹ�ü�Ȩ���
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "ֱ�����¿�������Bearer {token}",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                        },
                        new string[] {}
                    }
                        });
                #endregion
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            #region ʹ��Auto mapper
            builder.Services.AddAutoMapper(typeof(Automapper));
            #endregion
            #region �����������
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SignalR", builder =>
                {
                    builder
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(s => true);
                });
                options.AddPolicy("Allow", build =>
                {
                    build.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            #endregion

            //����Jwt��֤����
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>//����jwtBearer
            {
                //��֤jwt����Ϣ
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Authentication:Admin"],

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Authentication:User"],

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtPassword"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                        {
                            //��ֹĬ�ϵķ��ؽ��(������)
                            context.HandleResponse();
                            var result = JsonConvert.SerializeObject(new { Code = "401", Message = "��֤ʧ��" });
                            context.Response.ContentType = "application/json";
                            //��֤ʧ�ܷ���401
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.WriteAsync(result);
                            return Task.FromResult(0);
                        },

                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        //
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chathub"))
                        {
                            try
                            {
                                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                                IJsonSerializer serializer = new JsonNetSerializer();
                                IDateTimeProvider provider = new UtcDateTimeProvider();
                                IJwtValidator validator = new JwtValidator(serializer, provider);
                                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                                var json = decoder.DecodeToObject(accessToken.ToString().Split(' ')[1], Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtPassword"]), verify: true);
                                context.HttpContext.Response.Cookies.Append("userid", json["userid"].ToString());
                                context.Token = accessToken;
                            }
                            catch
                            {
                                throw;
                            }

                        }

                        return Task.CompletedTask;
                    }
                };
            });

            //����ʹ�������
            builder.Services.AddAuthorization(
                options =>
                {

                    for (int i = 0;i <= 2;i++)
                    {
                        options.AddPolicy(((Power_Enum.STUDENT_POWER) i).ToString(), policy => policy.RequireClaim(((Power_Enum.STUDENT_POWER) i).ToString()));
                    }
                    for (int i = 0;i <= 4;i++)
                    {
                        options.AddPolicy(((Power_Enum.TEACHER_POWER) i).ToString(), policy => policy.RequireClaim(((Power_Enum.TEACHER_POWER) i).ToString()));
                    }
                    for (int i = 0;i <= 3;i++)
                    {
                        options.AddPolicy(((Power_Enum.IDENTITY_TYPE) i).ToString(), policy => policy.RequireClaim(((Power_Enum.IDENTITY_TYPE) i).ToString()));
                    }
                });
            //����SQL Sugar
            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = "Data Source=DESKTOP-DG8FD91\\SQLEXPRESS;Initial Catalog=DIMS;User ID=sa;Password=123456",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true,
                //ֱ��ʹ�� DbScoped.SugarScope �൱��EFcore��context
            });
            builder.Services.ConfigurationSugar(db =>
            {
                //�����Զ���ֱ���
                db.CurrentConnectionConfig.ConfigureExternalServices.SplitTableService = new CoustemSplitTables();
                //��ʼ���ֱ�
                db.CodeFirst.SplitTables().InitTables<live_info_build>();
                db.Aop.OnLogExecuting = (sql, p) =>
                {
                    Console.WriteLine(sql);
                };

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("SignalR");
            app.UseCors("Allow");
            app.MapControllers();
            app.MapHub<Hubs>("/chathub");

            app.Run();
        }
    }
}