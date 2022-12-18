using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Model.DbModels
{
    ///<summary>
    ///查寝分数
    ///</summary>
    [SugarTable("SCORE")]
    public partial class score
    {
        public score()
        {


        }
        /// <summary>
        /// Desc:房间标识
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "ROOM_ID")]
        public int room_id { get; set; }

        /// <summary>
        /// Desc:房间分数
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "ROOM_SCORE")]
        public double room_score { get; set; }

        /// <summary>
        /// Desc:查寝时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(ColumnName = "CHECK_TIME")]
        public DateTime? check_time { get; set; }

        /// <summary>
        /// Desc:年;yyyy0/1（0 1代表上 下半年）
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(ColumnName = "YEAR_TERM")]
        public string year_term { get; set; }

    }
}
