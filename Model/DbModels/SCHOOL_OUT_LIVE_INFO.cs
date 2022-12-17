using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///校外住宿档案
    ///</summary>
    [SugarTable("SCHOOL_OUT_LIVE_INFO")]
    public partial class school_out_live_info
    {
        public school_out_live_info()
        {


        }
        /// <summary>
        /// Desc:校外住宿申请事件ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "ID")]
        public int id { get; set; }

        /// <summary>
        /// Desc:学生状态
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_STATUS")]
        public string? student_status { get; set; }

        /// <summary>
        /// Desc:校外住宿风险
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "RISK")]
        public string? risk { get; set; }

        /// <summary>
        /// Desc:校外住宿状态;正在校外住宿/已作废
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STATUS")]
        public bool? status { get; set; }

    }
}
