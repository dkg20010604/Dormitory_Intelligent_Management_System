using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class class_info_dto
    {
        public string class_name{get;set;}
        public string? headmaster { get; set; }
        public string? instructor { get; set; }
    }
}
