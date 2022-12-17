using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///宿舍房间信息
    ///</summary>
    [SugarTable("ROOM_INFO")]
    public partial class room_info
    {
           public room_info(){


           }
           /// <summary>
           /// Desc:房间标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ROOM_ID")]
           public int room_id {get;set;}

           /// <summary>
           /// Desc:楼号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="BUILD_ID")]
           public int build_id {get;set;}

           /// <summary>
           /// Desc:房间号（楼层数*100+序列号）;楼层房间号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="ROOM_NUMBER")]
           public int room_number {get;set;}

           /// <summary>
           /// Desc:床数
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="BED_NUMBER")]
           public int bed_number {get;set;}

           /// <summary>
           /// Desc:电费
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="ELECTRICITY_FEES")]
           public double? electricity_fees {get;set;}

           /// <summary>
           /// Desc:物品是否缺失
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="LOST_THING")]
           public bool lost_thing {get;set;}

           /// <summary>
           /// Desc:缺失详情;根据价目表生成（例如：椅子x2 1400元 共计1400元）
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LOST_DETAIL")]
           public string? lost_detail {get;set;}

    }
}
