using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    /// <summary>
    /// 要给前端看，直接用中文
    /// </summary>
    public class Step_Enum
    {
        /// <summary>
        /// 换宿步骤
        /// </summary>
        public enum CHANGE_ROOM_STEP
        {
            /// <summary>
            /// 发起申请
            /// </summary>
            发起申请,
            /// <summary>
            /// 院系通过
            /// </summary>
            院系通过,
            /// <summary>
            /// 分配宿舍
            /// </summary>
            分配宿舍,
            /// <summary>
            /// 公寓管理中心通过
            /// </summary>
            公寓管理中心通过,
            /// <summary>
            /// 物品检查通过
            /// </summary>
            物品检查通过,
            /// <summary>
            /// 物业负责人通过
            /// </summary>
            物业负责人通过,
        }

        /// <summary>
        /// 退宿步骤
        /// </summary>
        public enum BACK_ROOM_STEP
        {
            /// <summary>
            /// 发起申请
            /// </summary>
            发起申请,
            /// <summary>
            /// 学院通过
            /// </summary>
            学院通过,
            /// <summary>
            /// 通知物业管理人
            /// </summary>
            通知物业管理人,
            /// <summary>
            /// 物业检查通过
            /// </summary>
            物业检查通过,
        }

        /// <summary>
        /// 入住步骤
        /// </summary>
        public enum INTO_STEP
        {
            /// <summary>
            /// 提出申请
            /// </summary>
            提出申请,
            /// <summary>
            /// 院系通过
            /// </summary>
            院系通过,
            /// <summary>
            /// 公寓管理中心通过
            /// </summary>
            公寓管理中心通过,
            /// <summary>
            /// 物业公司通过
            /// </summary>
            物业公司通过,
        }

        /// <summary>
        /// 校外住宿步骤
        /// </summary>
        public enum LIVE_OUT_STEP
        {
            /// <summary>
            /// 提出申请
            /// </summary>
            提出申请,
            /// <summary>
            /// 辅导员确认
            /// </summary>
            辅导员确认,
            /// <summary>
            /// 学院通过
            /// </summary>
            学院通过,
            /// <summary>
            /// 公寓中心通过
            /// </summary>
            公寓中心通过,
            /// <summary>
            /// 学生处通过
            /// </summary>
            学生处通过,
        }

    }
}
