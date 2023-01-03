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
using Npoi.Mapper;
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

        [HttpPost("addbuild")]
        public async Task<Http_Help<string>> addinfo()
        {
            //List<live_info_build> info = new List<live_info_build>();
            //var a = await DbScoped.SugarScope.Queryable<room_info>().Includes(s => s.dormitory_building_info).ToListAsync();
            //foreach (var item in a)
            //{
            //    for (int i = 1;i <= item.bed_number;i++)
            //    {
            //        info.Add(new live_info_build
            //        {
            //            main_key = (item.room_number * 100) + i,
            //            room_id = item.room_id,
            //            bed_id = i,
            //            role = false,
            //            build_id = item.build_id
            //        });
            //    }
            //}
            //var c =await DbScoped.SugarScope.Insertable(info).SplitTable().ExecuteCommandAsync();
            return new Http_Helper<string>().Succeed("成功", "dsdsa");
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
            //主表不能直接导航分表查询，只能leftjoin然后手动select
            var a = DbScoped.SugarScope.Queryable<room_info>()
                .LeftJoin(DbScoped.SugarScope.Queryable<live_info_build>()
                    .SplitTable(t => t.Take(10)/*精确查询可以用手动指定 t => t.Where(s=>s.TableName.Contains("2"))*/), (s, l) => s.room_id == l.room_id).Where("")//.Includes()...
                .Select((s, l) => new
                {
                    build_id = l.build_id,
                    room_number = s.room_number,
                })
                .ToList();

            return new Http_Helper<string>().Succeed("chengg", "dsa");
        }
    }
}
