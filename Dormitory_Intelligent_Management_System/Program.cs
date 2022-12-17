using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using SqlSugar.IOC;
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
            //builder.Services.AddAutoMapper();
            #endregion
            #region 允许跨域请求
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Allow", builder =>
                {
                    builder
                    .AllowCredentials()
                    .WithOrigins("127.0.0.1")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(s => true);
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
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Authentication:Admin"],

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Authentication:User"],

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtPassword"]))
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
                ConnectionString = "Data Source=DESKTOP-54954D6\\SQLEXPRESS;Initial Catalog=DIMS;User ID=sa;Password=123456",
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
            app.UseCors("SignalR");
            app.MapControllers();
            app.MapHub<SignalR.Hubs>("/chathub");

            app.Run();
        }
    }
}