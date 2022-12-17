using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///维修事务
    ///</summary>
    [SugarTable("REPAIR_WORK")]
    public partial class repair_work
    {
           public repair_work(){


           }
           /// <summary>
           /// Desc:事件标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int id {get;set;}

           /// <summary>
           /// Desc:提交人学号/工号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STUDENT_ID")]
           public string student_id {get;set;}

           /// <summary>
           /// Desc:详细信息
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="DETAILED_INFORMATION")]
           public string detailed_information {get;set;}

           /// <summary>
           /// Desc:事件状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STATUS")]
           public int status {get;set;}

           /// <summary>
           /// Desc:当前处理人
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="HANDLED")]
           public string handled {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="CREATED_TIME")]
           public int? created_time {get;set;}

    }
}
