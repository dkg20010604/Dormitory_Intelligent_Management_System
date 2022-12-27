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
                    options.AddPolicy("权限名", policy => policy.RequireClaim("权限名"));//与生成jwt时claim相对应
                });

            builder.Services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = "Data Source=118.190.201.1;Initial Catalog=DIMS;User ID=sa;Password=123456789",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true,
                //直接使用 DbScoped.SugarScope 相当于EFcore的context
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