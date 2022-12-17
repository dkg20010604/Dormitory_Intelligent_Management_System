using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///校外住宿申请提交
    ///</summary>
    [SugarTable("SCHOOL_OUT_LIVE")]
    public partial class school_out_live
    {
           public school_out_live(){


           }
           /// <summary>
           /// Desc:校外住宿申请事件ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int id {get;set;}

           /// <summary>
           /// Desc:学号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STUDENT_ID")]
           public string student_id {get;set;}

           /// <summary>
           /// Desc:出生年月
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="BIRTH_DATE")]
           public DateTime? birth_date {get;set;}

           /// <summary>
           /// Desc:学生电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="STUD_PHONE")]
           public string? stud_phone {get;set;}

           /// <summary>
           /// Desc:家长电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="PARENT_PHONE")]
           public string? parent_phone {get;set;}

           /// <summary>
           /// Desc:住宿方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LIVE_TYPE")]
           public int? live_type {get;set;}

           /// <summary>
           /// Desc:家庭地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="HOME_LOCATION")]
           public string? home_location {get;set;}

           /// <summary>
           /// Desc:校外住宿地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LIVE_LOCATION")]
           public string? live_location {get;set;}

           /// <summary>
           /// Desc:原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LIVE_OUT_REASON")]
           public string? live_out_reason {get;set;}

           /// <summary>
           /// Desc:家长意见
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="PARENT_OPINION")]
           public string? parent_opinion {get;set;}

           /// <summary>
           /// Desc:申请时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="APPLY_TIME")]
           public DateTime? apply_time {get;set;}

    }
}
