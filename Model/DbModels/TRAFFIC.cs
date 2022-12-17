using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///人员流动
    ///</summary>
    [SugarTable("TRAFFIC")]
    public partial class traffic
    {
           public traffic(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int id {get;set;}

           /// <summary>
           /// Desc:身份证
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="IDCARD")]
           public string? idcard {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="NAME")]
           public string? name {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="PHION_NUMBER")]
           public string phion_number {get;set;}

           /// <summary>
           /// Desc:进时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="COME_TIME")]
           public DateTime? come_time {get;set;}

           /// <summary>
           /// Desc:出时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="OUT_TIME")]
           public DateTime? out_time {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="NOTES")]
           public string? notes {get;set;}

    }
}
