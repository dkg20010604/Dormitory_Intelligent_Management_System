using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Model.DbModels;
using SqlSugar.IOC;
using Static_Class.Result_Help;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Model.DTOModels;
using File_Services;
using Static_Class;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Spreadsheet;
using Npoi.Mapper;
using Org.BouncyCastle.Cms;

namespace Dormitory_Intelligent_Management_System.Controllers
{
    public class LoginInfo
    {
        public string username { get; set; }
        public string password { get; set; }
        /// <summary>
        /// 1:学生
        /// 2:老师
        /// 3:后勤
        /// </summary>
        public int power { get; set; }
    }
    [Route("api/[controller]/[action]")]
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
        public async Task<Http_Help<string>> Login([FromBody] LoginInfo loginInfo)
        {
            List<Claim> claims = new List<Claim>();
            bool run = false;
            run = true;
            claims = new Claim[]
                        {
                            new Claim("userid", loginInfo.username),
                            new Claim(((Power_Enum.STUDENT_POWER) 0).ToString(),"true"),//需要特定角色才能访问时在[HttpPost]下一行加上[Authorize(Policy = "身份名/权限名")]，可加多个，表示同时满足才可访问,身份名详见PowerEnum
                        new Claim(ClaimTypes.NameIdentifier, loginInfo.username),
                        }.ToList();
            if (loginInfo.power == 1)
            {
                #region 学生登陆验证
                var user = await DbScoped.SugarScope.Queryable<students_info>().InSingleAsync(loginInfo.username);
                if (user == null)
                {
                    return new Http_Helper<string>().Error("账号不存在");
                }
                if (MD5_Services.GenerateMD5(loginInfo.password) == user.password)//通过
                {
                    claims.Add(new Claim("user_id", user.student_id));
                    run = true;
                    foreach (var item in user.powers)
                    {
                        claims.Add(new Claim(((Power_Enum.STUDENT_POWER) item).ToString(), "true"));
                    }
                }
                else
                    return new Http_Helper<string>().Error("密码错误");
                #endregion
            }
            else if (loginInfo.power == 2)
            {
                #region 老师登陆验证
                var user = await DbScoped.SugarScope.Queryable<teachers>().InSingleAsync(loginInfo.username);
                if (user == null)
                {
                    return new Http_Helper<string>().Error("账号不存在");
                }
                if (MD5_Services.GenerateMD5(loginInfo.password) == user.password)//通过
                {
                    claims.Add(new Claim("user_id", user.administered_id));
                    run = true;
                    foreach (var item in user.powers)
                    {
                        claims.Add(new Claim(((Power_Enum.TEACHER_POWER) item).ToString(), "true"));
                    }
                }
                else
                    return new Http_Helper<string>().Error("密码错误");
                #endregion
            }
            else
            {
                #region 后勤登陆验证
                var user = await DbScoped.SugarScope.Queryable<logistics>().InSingleAsync(loginInfo.username);
                if (user == null)
                {
                    return new Http_Helper<string>().Error("账号不存在");
                }
                if (MD5_Services.GenerateMD5(loginInfo.password) == user.password)//通过
                {
                    run = true;
                    claims.Add(new Claim("user_id", user.logistics_id));
                    foreach (var item in user.powers)
                    {
                        claims.Add(new Claim(((Power_Enum.IDENTITY_TYPE) item).ToString(), "true"));
                    }
                }
                else
                    return new Http_Helper<string>().Error("密码错误");
                #endregion
            }
            if (run)
            {
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
            {
                return new Http_Helper<string>().Error("密码错误");
            }

        }

        //[Authorize(Policy = "ROOT")]
        [HttpPost("GetCollege")]
        public async Task<Http_Help<List<college_info_dto>>> get_all()
        {
            return new Http_Helper<List<college_info_dto>>().Succeed("成功", _mapper.Map<List<college_info_dto>>(await DbScoped.SugarScope.Queryable<college_info>().Includes(c => c.major_infos).ToListAsync()));
        }

        [AllowAnonymous]
        [HttpGet("change_file")]
        public ActionResult Stream()
        {
            byte[] bytes = new File_Serve().Changeroom();
            return File(bytes, "application/msword", "student.docx");
        }
    }
}