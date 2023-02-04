using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class student_base_info_dto
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string student_id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string student_name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>           
        public char[] gender { get; set; }=new char[2];

        /// <summary>
        /// 身份证
        /// </summary>           
        public string identity_card { get; set; }

        /// <summary>
        /// 是否住宿
        /// </summary>           
        public bool status { get; set; }

        /// <summary>
        /// 权限
        /// </summary>           
        public List<string> power { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public string? class_info { get; set; }

        public string? instructor { get; set; }

        public string? headmaster { get; set; }
    }
}
