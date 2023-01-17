using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///宿舍楼信息
    ///</summary>
    [SugarTable("DORMITORY_BUILDING_INFO")]
    public partial class dormitory_building_info
    {
        public dormitory_building_info()
        {


        }
        /// <summary>
        /// Desc:楼号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, ColumnName = "BUILD_ID")]
        public int build_id { get; set; }

        /// <summary>
        /// Desc:楼层数
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "BUILD_FLOORS")]
        public int build_floors { get; set; }

        /// <summary>
        /// Desc:房间床数
        /// Default:
        /// Nullable:False
        /// </summary>   
        [SugarColumn(ColumnName = "ROOM_BED")]
        public int room_bed { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(room_info.build_id))]
        public List<room_info>? room_Infos { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(graduation_back_room.build_id))]
        public List<graduation_back_room>? room_back_rooms { get; set; }

        [Navigate(typeof(housemaster_info), nameof(housemaster_info.manager_buld), nameof(housemaster_info.housemaster_id))]
        public List<logistics>? logistics { get; set; }
    }
}
