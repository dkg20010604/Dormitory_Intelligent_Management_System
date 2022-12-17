using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///公告
    ///</summary>
    [SugarTable("NOTICETHING")]
    public partial class noticething
    {
           public noticething(){


           }
           /// <summary>
           /// Desc:公告标识（唯一）
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="THING_ID")]
           public int thing_id {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="NOTICE_TITLE")]
           public string? notice_title {get;set;}

           /// <summary>
           /// Desc:公告正文
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="NOTICE_TEXT")]
           public string? notice_text {get;set;}

           /// <summary>
           /// Desc:发布人
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="RELEASE")]
           public string? release {get;set;}

           /// <summary>
           /// Desc:发布时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="UPDATED_TIME")]
           public DateTime? updated_time {get;set;}

           /// <summary>
           /// Desc:附件目录
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="SRC")]
           public string? src {get;set;}

           /// <summary>
           /// Desc:是否置顶
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="UP_OR_DOWN")]
           public bool up_or_down {get;set;}

           /// <summary>
           /// Desc:置顶有效期
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="UP_TIME")]
           public DateTime? up_time {get;set;}

    }
}
