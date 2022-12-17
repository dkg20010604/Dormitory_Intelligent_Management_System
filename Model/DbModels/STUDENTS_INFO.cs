﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///学生信息
    ///</summary>
    [SugarTable("STUDENTS_INFO")]
    public partial class students_info
    {
           public students_info(){


           }
           /// <summary>
           /// Desc:学号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,ColumnName="STUDENT_ID")]
           public string student_id {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STUDENT_NAME")]
           public string student_name {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="GENDER")]
           public bool gender {get;set;}

           /// <summary>
           /// Desc:身份证
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="IDENTITY_CARD")]
           public string identity_card {get;set;}

           /// <summary>
           /// Desc:班级代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="CLASS_ID")]
           public int? class_id {get;set;}

           /// <summary>
           /// Desc:是否住宿
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="STATUS")]
           public bool status {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="PASSWORD")]
           public string? password {get;set;}

           /// <summary>
           /// Desc:权限
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="POWER")]
           public int? power {get;set;}

    }
}