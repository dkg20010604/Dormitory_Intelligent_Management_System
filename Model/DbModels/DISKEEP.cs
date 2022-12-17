using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///违纪记录
    ///</summary>
    [SugarTable("DISKEEP")]
    public partial class diskeep
    {
           public diskeep(){


           }
           /// <summary>
           /// Desc:学号
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="STUDENT_ID")]
           public string? student_id {get;set;}

           /// <summary>
           /// Desc:违规类型
           /// Default:DIS_RETURN
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="DISKEEP_TYPE")]
           public int? diskeep_type {get;set;}

           /// <summary>
           /// Desc:违规时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="DISKEEP_TIME")]
           public DateTime? diskeep_time {get;set;}

    }
}
