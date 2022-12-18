using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///居住信息;一楼一表，显示全部床信息，不管有无居住人员
    ///</summary>
    [SugarTable("LIVE_INFO_BUILD_ID1")]
    public partial class live_info_build_id1
    {
        public live_info_build_id1()
        {


        }
        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_ID")]
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

        [Navigate(NavigateType.ManyToOne, nameof(room_id))]
        public room_info room_Info { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(student_id))]
        public students_info students_Info { get; set; }
    }
}
