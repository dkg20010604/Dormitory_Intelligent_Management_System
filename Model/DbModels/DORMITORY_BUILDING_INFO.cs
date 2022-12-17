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
           public dormitory_building_info(){


           }
           /// <summary>
           /// Desc:楼号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,ColumnName="BUILD_ID")]
           public int build_id {get;set;}

           /// <summary>
           /// Desc:楼层数
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="BUILD_FLOORS")]
           public int build_floors {get;set;}

           /// <summary>
           /// Desc:房间床数
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="ROOM_BED")]
           public int room_bed {get;set;}

    }
}
