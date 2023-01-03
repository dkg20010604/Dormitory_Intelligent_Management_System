using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///居住信息;一楼一表，显示全部床信息，不管有无居住人员
    ///表名：LIVE_INFO_BUILD_楼号
    ///</summary>
    [SplitTable(SplitType._Custom01)]
    [SugarTable("LIVE_INFO_")]
    public partial class live_info_build
    {
        public live_info_build()
        {


        }
        /// <summary>
        /// 主键 无实际意义 房间号*100+床号
        /// 如 20101//房间号为201的房间 1号床
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "MAIN_KEY")]
        public long main_key { get; set; }
        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_ID", IsNullable = true)]
        public string? student_id { get; set; }

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
        /// Desc:是否为舍长
        /// Default:false
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "ROLE")]
        public bool role { get; set; }
        /// <summary>
        /// 分表标识：楼号
        /// </summary>
        [SplitField]
        public int build_id { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(room_id))]
        public room_info room_Info { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(student_id))]
        public students_info students_Info { get; set; }
    }
}
