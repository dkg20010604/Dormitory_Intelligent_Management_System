using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using System.Runtime.InteropServices;

namespace Dormitory_Intelligent_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : ControllerBase
    {
        [HttpPost]
        public byte[] getfile()
        {
            var file = HttpContext.Request.Form.Files.First();
            byte[] result;
            if (file != null)
            {
                result = new byte[file.Length];
                Stream stream = file.OpenReadStream();
                stream.Read(result, 0, result.Length);
                return result;
            }
            return new byte[1];
        }
    }
}
