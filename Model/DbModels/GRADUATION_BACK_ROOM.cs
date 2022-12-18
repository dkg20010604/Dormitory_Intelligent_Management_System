using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///毕业退宿
    ///</summary>
    [SugarTable("GRADUATION_BACK_ROOM")]
    public partial class graduation_back_room
    {
        public graduation_back_room()
        {


        }
        /// <summary>
        /// Desc:楼号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "BUILD_ID")]
        public int? build_id { get; set; }

        /// <summary>
        /// Desc:房间标识
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "ROOM_ID")]
        public int? room_id { get; set; }

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

    }
}
