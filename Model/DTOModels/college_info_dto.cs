using Model.DbModels;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class college_info_dto
    {
        public int college_id { get; set; }
        public string? college_name { get; set; }
        public List<major_info> major_infos { get; set; }
    }
}
