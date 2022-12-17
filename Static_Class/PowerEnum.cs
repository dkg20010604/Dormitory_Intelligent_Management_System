namespace Static_Class
{
    public class PowerEnum
    {
        /// <summary>
        /// 学生权限
        /// </summary>
        enum STUDENT_POWER
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
        enum TEACHER_POWER
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
        /// 班级类型
        /// </summary>
        enum CLASSTYPE
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
        /// 后勤角色
        /// </summary>
        enum IDENTITY_TYPE
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
        /// <summary>
        /// 换宿步骤
        /// </summary>
        enum CHANGE_ROOM_STEP
        {
            /// <summary>
            /// 发起申请
            /// </summary>
            APPLY,
            /// <summary>
            /// 院系通过
            /// </summary>
            COLLEGE_ADOPT,
            /// <summary>
            /// 分配宿舍
            /// </summary>
            FIND_ROOM,
            /// <summary>
            /// 公寓管理中心通过
            /// </summary>
            MANAGEMENT_CENTER,
            /// <summary>
            /// 物品检查通过
            /// </summary>
            GOODS_CHECK,
            /// <summary>
            /// 物业负责人通过
            /// </summary>
            MANAGEMENT_ADMIN,
        }
        /// <summary>
        /// 结果
        /// </summary>
        enum THING_RESULT
        {
            /// <summary>
            /// 进行中
            /// </summary>
            RUNNING,
            /// <summary>
            /// 通过
            /// </summary>
            OK,
            /// <summary>
            /// 拒绝
            /// </summary>
            OUT,
            /// <summary>
            /// 已撤回
            /// </summary>
            BACK,
        }
        /// <summary>
        /// 退宿步骤
        /// </summary>
        enum BACK_ROOM_STEP
        {
            /// <summary>
            /// 发起申请
            /// </summary>
            APPLY,
            /// <summary>
            /// 学院通过
            /// </summary>
            COLLEGE_PASS,
            /// <summary>
            /// 通知物业管理人
            /// </summary>
            CALL_MANAGER,
            /// <summary>
            /// 物业检查通过
            /// </summary>
            MANAGER_PASS,
        }
        /// <summary>
        /// 入住步骤
        /// </summary>
        enum INTO_STEP
        {
            /// <summary>
            /// 提出申请
            /// </summary>
            APPLY,
            /// <summary>
            /// 院系通过
            /// </summary>
            COLLEGE_PASS,
            /// <summary>
            /// 公寓管理中心通过
            /// </summary>
            CENTER_PASS,
            /// <summary>
            /// 物业公司通过
            /// </summary>
            ENDING,
        }
        /// <summary>
        /// 校外住宿方式
        /// </summary>
        enum OUT_SCHOOL_LIVE_TYPE
        {
            /// <summary>
            /// 实习单位
            /// </summary>
            INTERNSHIP,
            /// <summary>
            /// 自家
            /// </summary>
            OWN_HOME,
            /// <summary>
            /// 亲戚家
            /// </summary>
            RELATIVES,
            /// <summary>
            /// 其他
            /// </summary>
            OTHER,
        }
        /// <summary>
        /// 校外住宿步骤
        /// </summary>
        enum LIVE_OUT_STEP
        {
            /// <summary>
            /// 提出申请
            /// </summary>
            APPLY,
            /// <summary>
            /// 辅导员确认
            /// </summary>
            INSTRUCTOR_PASS,
            /// <summary>
            /// 学院通过
            /// </summary>
            COLLEGE_PASS,
            /// <summary>
            /// 公寓中心通过
            /// </summary>
            BUILD_CENTER_PASS,
            /// <summary>
            /// 学生处通过
            /// </summary>
            STUDENT_OFFICE_PASS,
        }
        /// <summary>
        /// 违规类型
        /// </summary>
        enum DISS_KEEP_TYPE
        {
            /// <summary>
            /// 夜不归宿
            /// </summary>
            NOT_BACK,
            /// <summary>
            /// 饲养动物
            /// </summary>
            FEET_ANIMAL,
            /// <summary>
            /// 违规电器
            /// </summary>
            ILLEGAL_ELECTRICAL,
            /// <summary>
            /// 打架
            /// </summary>
            FIGHT,
            /// <summary>
            /// 其他
            /// </summary>
            OTHER,
        }
        /// <summary>
        /// 维修状态
        /// </summary>
        enum MAINTENANCE_STATUS
        {
            /// <summary>
            /// 进行中
            /// </summary>
            RUNNING,
            /// <summary>
            /// 完成
            /// </summary>
            FINISH,
            /// <summary>
            /// 已取消
            /// </summary>
            CANCEL,
        }
    }
}
