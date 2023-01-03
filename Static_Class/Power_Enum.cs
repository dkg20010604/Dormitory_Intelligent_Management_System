namespace Static_Class
{
    public class Power_Enum
    {
        /// <summary>
        /// 学生权限
        /// </summary>
        public enum STUDENT_POWER
        {
            /// <summary>
            /// 普通学生
            /// </summary>
            NORMAL,
            /// <summary>
            /// 院级宿检部
            /// </summary>
            COLLAGE_INSPECT,
            /// <summary>
            /// 校级宿检部
            /// </summary>
            FIELD_INSPECT,
        }

        /// <summary>
        /// 老师权限
        /// </summary>
        public enum TEACHER_POWER
        {
            /// <summary>
            /// 基础权限
            /// </summary>
            BASE_POWER,
            /// <summary>
            /// 院级管理
            /// </summary>
            COLLEGE,
            /// <summary>
            /// 院级书记
            /// </summary>
            COLLEGE_SECRETARY,
            /// <summary>
            /// 临时校级管理员
            /// </summary>
            TEMP_ROOT,
            /// <summary>
            /// 超级管理员
            /// </summary>
            ROOT,
        }
        
        /// <summary>
        /// 后勤权限
        /// </summary>
        public enum IDENTITY_TYPE
        {
            /// <summary>
            /// 公寓中心
            /// </summary>
            IDENTITY_CENTER,
            /// <summary>
            /// 公寓负责人
            /// </summary>
            IDENTITY_CHARGE,
            /// <summary>
            /// 学生处
            /// </summary>
            STUDENT_OFFICE,
            /// <summary>
            /// 宿管
            /// </summary>
            HOUSE_MASTER,
        }
    }
}
