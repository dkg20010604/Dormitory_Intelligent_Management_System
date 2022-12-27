using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using SqlSugar.IOC;
using Newtonsoft.Json;
using Model.AutoMapperProfile;

namespace Dormitory_Intelligent_Management_System
{
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
            builder.Services.AddAutoMapper(typeof(automapper));
            #endregion
            #region �����������
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
                    }
                };
            });
            //����ʹ�������
            builder.Services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Ȩ����", policy => policy.RequireClaim("Ȩ����"));//������jwtʱclaim���Ӧ
                });

            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = "Data Source=118.190.201.1;Initial Catalog=DIMS;User ID=sa;Password=123456789",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true,
                //ֱ��ʹ�� DbScoped.SugarScope �൱��EFcore��context
            });
            builder.Services.ConfigurationSugar(db =>
            {

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