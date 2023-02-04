using AutoMapper;
using Dormitory_Intelligent_Management_System.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Model.DbModels;
using Model.DTOModels;
using Org.BouncyCastle.Utilities;
using SqlSugar;
using SqlSugar.IOC;
using Static_Class.Result_Help;
using System.Runtime.InteropServices;

namespace Dormitory_Intelligent_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IHubContext<Hubs> _hub;
        public readonly IMapper _mapper;
        public LogisticsController(IConfiguration configuration, IHubContext<Hubs> hub, IMapper mapper)
        {
            _configuration = configuration;
            _hub = hub;
            _mapper = mapper;
        }
        //获取宿管信息
        [HttpGet]
        public async Task<Http_Help<List<logistics_info_dto>>> GetLogistics()
        {
            return new Http_Helper<List<logistics_info_dto>>().Succeed("成功", _mapper.Map<List<logistics_info_dto>>(await DbScoped.SugarScope.Queryable<logistics>().Where(l=>SqlFunc.JsonArrayAny(l.powers,2)).ToListAsync()));
        }
    }
}
