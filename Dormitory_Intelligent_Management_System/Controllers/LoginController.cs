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
using Npoi.Mapper.Attributes;
using Model.DTOModels;
using File_Services;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using RestSharp;

namespace Dormitory_Intelligent_Management_System.Controllers
{
    public class LoginInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class nameob
    {
        [Column("姓名")]
        public string name { get; set; }
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
                    new Claim("userid", loginInfo.username),
                    new Claim("身份名/权限名","true"),//需要特定角色才能访问时在[HttpPost]下一行加上[Authorize(Policy = "身份名/权限名")]，可加多个，表示同时满足才可访问,身份名详见PowerEnum
                    new Claim(ClaimTypes.NameIdentifier, loginInfo.username),
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

        [HttpPost("GetCollege")]
        public async Task<Http_Help<List<college_info_dto>>> get_all()
        {
            return new Http_Helper<List<college_info_dto>>().Succeed("成功", _mapper.Map<List<college_info_dto>>(await DbScoped.SugarScope.Queryable<college_info>().ToListAsync()));
        }

        [HttpPost("search1")]
        public async Task<Http_Help<string>> navgat()
        {
            //要导航查询(分表是主表)这么写,可以传楼号，也可以直接传 live_info_build 类
            var tablename = DbScoped.SugarScope.SplitHelper<live_info_build>().GetTableName(2);

            var a = DbScoped.SugarScope.Queryable<live_info_build>().AS(tablename).Includes(s => s.room_Info).ToList();

            return new Http_Helper<string>().Succeed("chengg", "dsa");
        }

        [HttpPost("search2")]
        public async Task<Http_Help<string>> navigate()
        {
            //主表导航分表使用
            var list = DbScoped.SugarScope.Queryable<room_info>().ToList();
            DbScoped.SugarScope.ThenMapper(list, live =>
            {
                live.live_infos = DbScoped.SugarScope.Queryable<live_info_build>()
                .SplitTable(t => t.Where(n => n.TableName.Contains(live.build_id.ToString())))
                .SetContext(s => s.room_id, () => live.room_id, live)
                .ToList();
            });
            DbScoped.SugarScope.ThenMapper(list.SelectMany(l => l.live_infos), live =>
            {
                live.students_Info = DbScoped.SugarScope.Queryable<students_info>()
                .SetContext(s => s.student_id, () => live.student_id, live)
                .FirstOrDefault();
            });
            return new Http_Helper<string>().Succeed("chengg", "dsa");
        }

        [HttpGet("file")]
        public ActionResult Stream()
        {
            byte[] bytes = new File_Serve().Changeroom();
            return File(bytes, "application/msword","student.docx");
        }
    }
}
