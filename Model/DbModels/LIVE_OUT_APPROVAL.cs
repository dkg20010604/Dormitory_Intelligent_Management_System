using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///校外住宿审批
    ///</summary>
    [SugarTable("LIVE_OUT_APPROVAL")]
    public partial class live_out_approval
    {
        /// <summary>
        /// Desc:校外住宿申请事件ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "ID")]
        public int? id { get; set; }

        /// <summary>
        /// Desc:复核家长意见结果
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "RECONFIRM_RESULT")]
        public bool? reconfirm_result { get; set; }

        /// <summary>
        /// Desc:辅导员意见
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "INSTRUCTOR_OPINION")]
        public string? instructor_opinion { get; set; }

        /// <summary>
        /// Desc:辅导员时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "INSTRUCTOR_TIME")]
        public DateTime? instructor_time { get; set; }

        /// <summary>
        /// Desc:学院意见
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_OPINION")]
        public string? college_opinion { get; set; }

        /// <summary>
        /// Desc:学院时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_TIME")]
        public int? college_time { get; set; }

        /// <summary>
        /// Desc:公寓中心意见
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "BUILD_CENTER_OPTION")]
        public bool? build_center_option { get; set; }

        /// <summary>
        /// Desc:公寓管理中心时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "BUILD_CENTER_TIME")]
        public DateTime? build_center_time { get; set; }

        /// <summary>
        /// Desc:学生处意见
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_OFFICE")]
        public string? student_office { get; set; }

        /// <summary>
        /// Desc:学生处时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_OFFICE_TIME")]
        public DateTime? student_office_time { get; set; }

        /// <summary>
        /// Desc:步骤
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STEP")]
        public int? step { get; set; }

        /// <summary>
        /// Desc:结果
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "FINALLY")]
        public int? finall { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(id))]
        public school_out_live school_out_live { get; set; }
    }
}
