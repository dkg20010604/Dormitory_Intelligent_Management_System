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

namespace Dormitory_Intelligent_Management_System
{
    public class CoustemSplitTables : ISplitTableService
    {
        /// <summary>
        /// 查找所有分表
        /// </summary>
        /// <param name="db"></param>
        /// <param name="EntityInfo"></param>
        /// <param name="tableInfos"></param>
        /// <returns></returns>
        public List<SplitTableInfo> GetAllTables(ISqlSugarClient db, EntityInfo EntityInfo, List<DbTableInfo> tableInfos)
        {
            List<SplitTableInfo> splits = new List<SplitTableInfo>();
            foreach (var item in tableInfos)
            {
                if (item.Name.Contains("_BUILD_ID_"))
                {
                    splits.Add(new SplitTableInfo()
                    {
                        TableName = item.Name //要用item.name不要写错了
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
            return EntityInfo.DbTableName + "BUILD_ID_1";
        }

        public string GetTableName(ISqlSugarClient db, EntityInfo EntityInfo, SplitType type)
        {
            return EntityInfo.DbTableName + "BUILD_ID_1";
        }

        public string GetTableName(ISqlSugarClient db, EntityInfo entityInfo, SplitType splitType, object fieldValue)
        {
            return entityInfo.DbTableName + "BUILD_ID_" + ((int)fieldValue).ToString();
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
            builder.Services.AddSwaggerGen(c =>
            {
                #region Swagger使用鉴权组件
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "直接在下框中输入Bearer {token}",
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
            #region 使用Auto mapper
            builder.Services.AddAutoMapper(typeof(automapper));
            #endregion
            #region 允许跨域请求
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("signalr", builder =>
                {
                    builder
                    .AllowCredentials()
                    .WithOrigins("http://localhost:5173/")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(s => true);
                });
                options.AddPolicy("allow_all", p =>
                {
                    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            #endregion

            //配置Jwt认证服务
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>//配置jwtBearer
            {
                //验证jwt串信息
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
                        //终止默认的返回结果(必须有)
                        context.HandleResponse();
                        var result = JsonConvert.SerializeObject(new { Code = "401", Message = "验证失败" });
                        context.Response.ContentType = "application/json";
                        //验证失败返回401
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.WriteAsync(result);
                        return Task.FromResult(0);
                    }
                };
            });

            //配置使用者身份
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
            //配置SQL Sugar
            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = "Data Source=DESKTOP-54954D6\\SQLEXPRESS;Initial Catalog=DIMS;User ID=sa;Password=123456",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true,
                //直接使用 DbScoped.SugarScope 相当于EFcore的context
            });
            builder.Services.ConfigurationSugar(db =>
            {
                db.CurrentConnectionConfig.ConfigureExternalServices.SplitTableService = new CoustemSplitTables();
                //初始化分表
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
            app.UseCors("signalr");
            app.UseCors("allow_all");
            app.MapControllers();
            app.MapHub<SignalR.Hubs>("/chathub");

            app.Run();
        }
    }
}