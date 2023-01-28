using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///宿管 所管的楼信息
    ///</summary>
    [SugarTable("HOUSEMASTER_INFO")]
    public partial class housemaster_info
    {
        public housemaster_info()
        {


        }
        /// <summary>
        /// Desc:后勤人员工号
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "HOUSEMASTER_ID")]
        public string housemaster_id { get; set; }

        /// <summary>
        /// Desc:所管楼号
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(ColumnName = "MANAGER_BULD")]
        public int? manager_buld { get; set; }
    }
}
