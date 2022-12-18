using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///专业信息
    ///</summary>
    [SugarTable("MAJOR_INFO")]
    public partial class major_info
    {
        public major_info()
        {


        }
        /// <summary>
        /// Desc:专业代码
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "MAJOR_ID")]
        public int major_id { get; set; }

        /// <summary>
        /// Desc:专业名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "MAJOR_NAME")]
        public string? major_name { get; set; }

        /// <summary>
        /// Desc:学院代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_ID")]
        public int? college_id { get; set; }

        /// <summary>
        /// Desc:状态（是否启用）
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "STATUS")]
        public bool status { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(class_info.major_id))]
        public List<class_info> class_infos { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(college_id))]
        public college_info college_Info { get; set; }
    }
}
