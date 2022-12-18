using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///学院信息
    ///</summary>
    [SugarTable("COLLEGE_INFO")]
    public partial class college_info
    {
        public college_info()
        {


        }
        /// <summary>
        /// Desc:学院代码
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "COLLEGE_ID")]
        public int college_id { get; set; }

        /// <summary>
        /// Desc:学院名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "COLLEGE_NAME")]
        public string? college_name { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(major_info.college_id))]
        public List<major_info> major_infos { get; set; }

    }
}
