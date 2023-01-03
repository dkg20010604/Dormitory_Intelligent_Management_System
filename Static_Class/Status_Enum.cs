using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    //要给前端的数据，直接用中文标识
    public class Status_Enum
    {
        /// <summary>
        /// 事件状态
        /// </summary>
        public enum THING_RESULT
        {
            /// <summary>
            /// 进行中
            /// </summary>
            进行中,
            /// <summary>
            /// 通过
            /// </summary>
            通过,
            /// <summary>
            /// 拒绝
            /// </summary>
            拒绝,
            /// <summary>
            /// 已撤回
            /// </summary>
            已撤回,
        }

        /// <summary>
        /// 维修状态
        /// </summary>
        public enum MAINTENANCE_STATUS
        {
            /// <summary>
            /// 进行中
            /// </summary>
            进行中,
            /// <summary>
            /// 完成
            /// </summary>
            完成,
            /// <summary>
            /// 已取消
            /// </summary>
            已取消,
        }
    }
}
