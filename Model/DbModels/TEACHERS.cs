using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///老师信息
    ///</summary>
    [SugarTable("TEACHERS")]
    public partial class teachers
    {
        public teachers()
        {


        }
        /// <summary>
        /// Desc:登录账号（同工号）
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, ColumnName = "ADMINISTERED_ID")]
        public string administered_id { get; set; }

        /// <summary>
        /// Desc:登陆密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "PASSWORD")]
        public string password { get; set; }

        /// <summary>
        /// Desc:姓名;为空显示为账号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "ADMIN_NAME")]
        public string? admin_name { get; set; }

        /// <summary>
        /// Desc:手机号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "PHONE")]
        public string? phone { get; set; }

        /// <summary>
        /// Desc:权限
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "POWERS", IsJson = true, ColumnDataType = "nvarchar(200)")]
        public List<int> powers { get; set; }

        /// <summary>
        /// Desc:印章地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "SRC_LOACTION")]
        public string? src_loaction { get; set; }

        /// <summary>
        /// 所在院系id
        /// </summary>
        [SugarColumn(ColumnName = "COLLEGE_ID")]
        public int? college_id { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(class_info.headmaster))]
        public List<class_info> by_headmaster { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(class_info.instructor))]
        public List<class_info> by_instructor { get; set; }

        [Navigate(NavigateType.ManyToOne, nameof(college_id))]
        public college_info college_Info { get; set; }
    }
}
