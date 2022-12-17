using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///后勤人员
    ///</summary>
    [SugarTable("LOGISTICS")]
    public partial class logistics
    {
           public logistics(){


           }
           /// <summary>
           /// Desc:后勤人员工号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,ColumnName="LOGISTICS_ID")]
           public string logistics_id {get;set;}

           /// <summary>
           /// Desc:后勤账号密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="LOGISTICS_POWER")]
           public string logistics_power {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LOGISTICS_NAME")]
           public string? logistics_name {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LOGISTICS_PHONE")]
           public string? logistics_phone {get;set;}

           /// <summary>
           /// Desc:后勤身份
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LOGISTICS_IDENTITY")]
           public int? logistics_identity {get;set;}

           /// <summary>
           /// Desc:印章地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="LOGISTICS_SRC")]
           public string? logistics_src {get;set;}

    }
}
