using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///入住申请;若不通过，直接修改结果为不通过，取消各个阶段的意见结果字段
    ///</summary>
    [SugarTable("BACK_LIVE")]
    public partial class back_live
    {
        public back_live()
        {


        }
        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_ID")]
        public string student_id { get; set; }

        /// <summary>
        /// Desc:入住原因
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "REASON")]
        public string reason { get; set; }

        /// <summary>
        /// Desc:申请时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "APPLY_TIME")]
        public DateTime apply_time { get; set; }

        /// <summary>
        /// Desc:学院意见
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_OPINION")]
        public string? college_opinion { get; set; }

        /// <summary>
        /// Desc:学院意见时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_TIME")]
        public DateTime? college_time { get; set; }

        /// <summary>
        /// Desc:调宿目标的楼号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "TO_BUILD_ID")]
        public int? to_build_id { get; set; }

        /// <summary>
        /// Desc:调宿目标的房间号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "TO_ROOM")]
        public int? to_room { get; set; }

        /// <summary>
        /// Desc:调宿目标的床号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "TO_BED_ID")]
        public int? to_bed_id { get; set; }

        /// <summary>
        /// Desc:通过公寓中心时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "PASS_CENTER")]
        public DateTime? pass_center { get; set; }

        /// <summary>
        /// Desc:物业管理人时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "PASS_ADMI")]
        public DateTime? pass_admi { get; set; }

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

        [Navigate(NavigateType.ManyToOne, nameof(student_id))]
        public students_info students_info { get; set; }
    }
}
