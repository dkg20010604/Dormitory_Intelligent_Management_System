using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class teacher_info_dto
    {
        /// <summary>
        /// Desc:登录账号（同工号）
        /// Default:
        /// Nullable:False
        /// </summary>
        public string administered_id { get; set; }

        /// <summary>
        /// Desc:姓名;为空显示为账号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "ADMIN_NAME")]
        public string? admin_name { get; set; }

        /// <summary>
        /// Desc:手机号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "PHONE")]
        public string? phone { get; set; }

        /// <summary>
        /// Desc:权限
        /// Default:
        /// Nullable:False
        /// </summary>
        public string powers { get; set; }
    }
}
