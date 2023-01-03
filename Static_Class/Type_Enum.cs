using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    public class Type_Enum
    {
        /// <summary>
        /// 班级类型
        /// </summary>
        public enum CLASSTYPE
        {
            /// <summary>
            /// 1
            /// </summary>
            普本,
            /// <summary>
            /// 2
            /// </summary>
            普专,
            /// <summary>
            /// 3
            /// </summary>
            专升本,
            /// <summary>
            /// 4
            /// </summary>
            春季高考,
            /// <summary>
            /// 5
            /// </summary>
            校企合作,
        }

        /// <summary>
        /// 校外住宿方式
        /// </summary>
        public enum OUT_SCHOOL_LIVE_TYPE
        {
            /// <summary>
            /// 实习单位
            /// </summary>
            实习单位,
            /// <summary>
            /// 自家
            /// </summary>
            自家,
            /// <summary>
            /// 亲戚家
            /// </summary>
            亲戚家,
            /// <summary>
            /// 其他
            /// </summary>
            其他,
        }

        /// <summary>
        /// 违规类型
        /// </summary>
        public enum DISS_KEEP_TYPE
        {
            /// <summary>
            /// 夜不归宿
            /// </summary>
            夜不归宿,
            /// <summary>
            /// 饲养动物
            /// </summary>
            饲养动物,
            /// <summary>
            /// 违规电器
            /// </summary>
            违规电器,
            /// <summary>
            /// 打架
            /// </summary>
            打架,
            /// <summary>
            /// 其他
            /// </summary>
            其他,
        }
    }
}
