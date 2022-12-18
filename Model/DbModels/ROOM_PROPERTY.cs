using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///宿舍财产价目表
    ///</summary>
    [SugarTable("ROOM_PROPERTY")]
    public partial class room_property
    {
        public room_property()
        {


        }
        /// <summary>
        /// Desc:物品名
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, ColumnName = "THING_NAME")]
        public string thing_name { get; set; }

        /// <summary>
        /// Desc:价值
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "THINFG_PRICE")]
        public double thinfg_price { get; set; }

    }
}
