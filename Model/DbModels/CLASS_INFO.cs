using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///班级信息
    ///</summary>
    [SugarTable("CLASS_INFO")]
    public partial class class_info
    {
        public class_info()
        {


        }
        /// <summary>
        /// Desc:班级代码
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "CLASS_ID")]
        public int class_id { get; set; }

        /// <summary>
        /// Desc:专业代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "MAJOR_ID")]
        public int? major_id { get; set; }

        /// <summary>
        /// Desc:年级
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "GRADE")]
        public int grade { get; set; }

        /// <summary>
        /// Desc:班级
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "CLASS")]
        public int? class_number { get; set; }

        /// <summary>
        /// Desc:本/专科
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "NATURE")]
        public bool nature { get; set; }

        /// <summary>
        /// Desc:附加描述
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "ADDITIONAL")]
        public int additional { get; set; }

        /// <summary>
        /// Desc:班主任
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "HEADMASTER")]
        public string? headmaster { get; set; }

        /// <summary>
        /// Desc:辅导员
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "INSTRUCTOR")]
        public string? instructor { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(students_info.class_id))]
        public List<students_info> students_Infos { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(major_id))]
        public major_info major_Info { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(headmaster))]
        public teachers headmaster_info { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(instructor))]
        public teachers instructor_info { get; set; }
    }
}
