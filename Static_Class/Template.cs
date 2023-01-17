using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    public class Template
    {
        /// <summary>
        /// 获取调宿模板占位符
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> Chengeroom()
        {
            return new Dictionary<string, string>
            {
                { "申请人姓名", "董凯歌" },
                { "申请人性别", "男" },
                { "申请人院系", "数科院" },
                { "申请人班级", "软件工程19级" },
                { "申请人电话", "12345678945" },
                { "原住楼号", "7" },
                { "原住房间号", "101" },
                { "现住楼号", "9" },
                { "现住房间号", "110" },
                { "调宿理由", "有病" },
                { "申请时间", "215645" },
                { "院系意见", "同意" },
                { "老师姓名", "刘伟童" },
                { "通过院系时间", "2019.12.12" },
                { "公寓中心意见", "同意" },
                { "公寓中心姓名", "王华" },
                { "通过公寓中心时间", "2020.01.01" },
                { "物品检查结果", "合格" },
                { "检查人", "刘强" },
                { "检查时间", "2020.01.01" },
                { "负责人姓名", "李刚" },
                { "负责人时间", "2020.01.01" }
            };
        }

        //获取入住模板占位符
        public static Dictionary<string, string> Backlive()
        {
            return new Dictionary<string, string>{
                { "_name_", "" },
                { "_gender_", "" },
                { "_college_", "" },
                { "_class_", "" },
                { "_build_", "" },
                { "_room_", "" },
                { "_reason_", "" },
                { "_applicant_", "" },
                { "_applicationtime_", "" },
                { "_collegeopinion_", "" },
                { "_teachername_", "" },
                { "_teachertime_", "" },
                { "_centeropinion_", "" },
                { "_centername_", "" },
                { "_centertime_", "" },
                { "_propertyname_", "" },
                { "_propertytime_", "" },
            };
        }

        //获取退宿模板占位符
        public static Dictionary<string, string> Retreat()
        {
            return new Dictionary<string, string>
            {
                { "_name_", "" },
                { "_gender_", "" },
                { "_college_", "" },
                { "_class_", "" },
                { "_build_", "" },
                { "_room_", "" },
                { "_reason_", "" },
                { "_applicant_", "" },
                { "_applicationtime_", "" },
                { "_collegeopinion_", "" },
                { "_teachername_", "" },
                { "_teachertime_", "" },
                { "_centeropinion_", "" },
                { "_centername_", "" },
                { "_centertime_", "" },
                { "_check_", "" },
                { "_checker_", "" },
                { "_checktime_", "" },
                { "_head_", "" },
                { "_headtime_", "" },
            };
        }

        //获取毕业退宿占位符
        public static Dictionary<string, string> Endout()
        {
            return new Dictionary<string, string>
            {
                { "name1", "" },
                { "name2", "" },
                { "name3", "" },
                { "name4", "" },
                { "name5", "" },
                { "name6", "" },
                { "name7", "" },
                { "name8", "" },
                { "college", "" },
                { "build", "" },
                { "room", "" },
                { "major", "" },
                { "checkname", "" },
                { "stamp", "" },
            };
        }
    }
}
