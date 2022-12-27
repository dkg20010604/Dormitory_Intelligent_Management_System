using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Model.DbModels;
using Model.DTOModels;
using SQLitePCL;
using SqlSugar.IOC;
using Static_Class.Result_Help;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dormitory_Intelligent_Management_System.Controllers
{
    public class LoginInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IHubContext<SignalR.Hubs> _hub;
        public readonly IMapper _mapper;
        public LoginController(IConfiguration configuration, IHubContext<SignalR.Hubs> hub, IMapper mapper)
        {
            _configuration = configuration;
            _hub = hub;
            _mapper = mapper;
        }
        [HttpPost]

        public Http_Help<string> Login([FromBody] LoginInfo loginInfo)
        {
            //college_info college_Info = new college_info()
            //{
            //    college_id =0,
            //    college_name = "数据科学与计算机学院"
            //};

            //DbScoped.SugarScope.Insertable<college_info>(college_Info).ExecuteCommand();
            //return new Http_Helper<List<college_info>>().Succeed("OK", DbScoped.SugarScope.Queryable<college_info>().ToList());
            #region 登陆验证
            #endregion
            if (true)//通过
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginInfo.username),
                    new Claim("身份名/权限名","true")//需要特定角色才能访问时在[HttpPost]下一行加上[Authorize(Policy = "身份名/权限名")]，可加多个，表示同时满足才可访问,身份名详见PowerEnum
                };

                var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:JwtPassword"]);
                var signingKey = new SymmetricSecurityKey(secretByte);

                var token = new JwtSecurityToken(
                   issuer: _configuration["Authentication:Admin"],//发布者
                   audience: _configuration["Authentication:User"],//使用者
                   claims: claims,//基础数据
                   notBefore: DateTime.UtcNow,//发布时间
                   expires: DateTime.UtcNow.AddDays(10),//有效期10天
                   signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                   );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return new Http_Helper<string>().Succeed("成功", tokenString);
            }
            else
                return new Http_Helper<string>().Error("错误");
        }

        [HttpPost("addmajor")]
        public async Task<Http_Help<string>> addinfo(string major_name, int collid)
        {
            try
            {
                int a = await DbScoped.SugarScope.Insertable(new major_info()
                {
                    major_name = major_name,
                    college_id = collid
                }).ExecuteCommandAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return new Http_Helper<string>().Succeed("成功添加", major_name);
        }
        [HttpPost("get_and_addcollege")]
        public async Task<List<college_info_dto>> get(string collname)
        {
            //await DbScoped.SugarScope.Insertable(new college_info()
            //{
            //    college_name = collname
            //}).ExecuteCommandAsync();
            return _mapper.Map<List<college_info_dto>>(await DbScoped.SugarScope.Queryable<college_info>().Includes(p => p.major_infos).ToListAsync());
        }
    }
}
