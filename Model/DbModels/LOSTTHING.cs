using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///失物招领信息
    ///</summary>
    [SugarTable("LOSTTHING")]
    public partial class lostthing
    {
           public lostthing(){


           }
           /// <summary>
           /// Desc:标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int id {get;set;}

           /// <summary>
           /// Desc:上交人员
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="UP_PERSON")]
           public string? up_person {get;set;}

           /// <summary>
           /// Desc:申领人员
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="DOWN_PERSON")]
           public string? down_person {get;set;}

           /// <summary>
           /// Desc:失物信息
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="LOST_TEXT")]
           public string lost_text {get;set;}

           /// <summary>
           /// Desc:提交时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="UP_TIME")]
           public DateTime up_time {get;set;}

           /// <summary>
           /// Desc:申领时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="DOWN_TIME")]
           public DateTime? down_time {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STATUS")]
           public bool status {get;set;}

           /// <summary>
           /// Desc:发布人ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="PUBLIC_ID")]
           public string public_id {get;set;}

    }
}
