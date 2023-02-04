using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class logistics_info_dto
    {
        public string logistics_id { get; set; }
        public string? logistics_name { get; set; }
        public string? logistics_phone { get; set; }
        public List<string> power { get;}
    }
}
