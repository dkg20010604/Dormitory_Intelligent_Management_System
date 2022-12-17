using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SqlSugar.IOC;
using Static_Class.Result_Help;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        
        public Http_Help<string> Login([FromBody]LoginInfo loginInfo)
        {

            #region 登陆验证

            #endregion
            if (true)//通过
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginInfo.username),
                    new Claim("身份名/权限名","true")//需要特定角色才能访问时在[HttpPost]下一行加上[Authorize(Policy = "身份名/权限名")]，可加多个，表示同时满足才可访问
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
    }
}
