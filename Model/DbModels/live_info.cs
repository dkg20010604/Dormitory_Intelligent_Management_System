using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///居住信息;一楼一表，显示全部床信息，不管有无居住人员
    ///表名：LIVE_INFO_BUILD_ID_楼号
    ///</summary>
    [SugarTable("LIVE_INFO")]
    public partial class live_info
    {
        public live_info()
        {
        }

        /// <summary>
        /// 主键 无意义
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "MAIN_KEY", IsIdentity = true)]
        public int main_key { get; set; }

        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(ColumnName = "STUDENT_ID", IsNullable = true,Length = 12)]
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
        /// 楼号
        /// </summary>
        [SugarColumn(ColumnName = "BUILD_ID")]
        public int build_id { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(room_id))]
        public room_info? room_Info { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(student_id))]
        public students_info? students_Info { get; set; }
    }
}
