using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///历史居住信息;历史表
    ///</summary>
    [SplitTable(SplitType._Custom01)]
    [SugarTable("LIVE_INFO_OLD_")]
    public partial class live_info_old
    {
        public live_info_old()
        {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(ColumnName ="ID",IsPrimaryKey =true)]
        public long id { get; set; }

        /// <summary>
        /// Desc:楼号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "BUILD_ID")]
        public int? build_id { get; set; }

        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(ColumnName = "STUDENT_ID")]
        public string? student_id { get; set; }

        /// <summary>
        /// Desc:姓名
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(ColumnName = "STUDENT_NAME")]
        public string? student_name { get; set; }

        /// <summary>
        /// Desc:房间标识
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "ROOM_ID")]
        public int room_id { get; set; }

        /// <summary>
        /// Desc:床号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "BED_ID")]
        public int bed_id { get; set; }

        /// <summary>
        /// Desc:宿舍角色
        /// Default:false
        /// Nullable:False
        /// </summary>
        [SugarColumn(ColumnName = "ROLE")]
        public bool role { get; set; }

        /// <summary>
        /// 储存时间
        /// </summary>
        [SplitField]
        [SugarColumn(ColumnName = "DATA_TIME")]
        public int year { get; set; }
    }
}
