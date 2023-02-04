using System;
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
        public students_info()
        {


        }
        /// <summary>
        /// Desc:学号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, ColumnName = "STUDENT_ID")]
        public string student_id { get; set; }

        /// <summary>
        /// Desc:姓名
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "STUDENT_NAME")]
        public string student_name { get; set; }

        /// <summary>
        /// Desc:性别
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "GENDER")]
        public bool gender { get; set; }

        /// <summary>
        /// Desc:身份证
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "IDENTITY_CARD")]
        public string identity_card { get; set; }

        /// <summary>
        /// Desc:班级代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "CLASS_ID")]
        public int? class_id { get; set; }

        /// <summary>
        /// Desc:是否住宿
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "STATUS")]
        public bool status { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "PASSWORD")]
        public string? password { get; set; }

        /// <summary>
        /// Desc:权限
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(ColumnName = "POWERS", IsJson = true, ColumnDataType = "nvarchar(200)")]
        public List<int> powers { get; set; }

        /// <summary>
        /// 楼号
        /// </summary>
        [SugarColumn(ColumnName = "BUILD_ID")]
        public int build_id { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(class_id))]
        public class_info class_Info { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(student_id))]
        public live_info live_Info { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(school_out_live.student_id))]
        public List<school_out_live> school_out_lives { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(changeroom.student_id))]
        public List<changeroom> changerooms { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(back_live.student_id))]
        public List<back_live> back_Lives { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(build_id))]
        public dormitory_building_info dormitory { get; set; }
    }
}
