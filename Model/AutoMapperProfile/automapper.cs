using AutoMapper;
using Model.DbModels;
using Model.DTOModels;
using SqlSugar.IOC;
using Static_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.AutoMapperProfile
{
    public class automapper : Profile
    {
        public automapper()
        {
            //学院信息映射
            CreateMap<college_info, college_info_dto>();
            //学生基础信息映射
            CreateMap<students_info, student_base_info_dto>()
                .ForMember(p => p.class_info,
                option => option.MapFrom(src => src.class_Info.major_Info.major_name
                + src.class_Info.grade.ToString() + "级"
                + src.class_Info.class_number + "班"
                + src.class_Info.additional))
                .ForMember(p => p.headmaster, option => option.MapFrom(src => src.class_Info.headmaster_info.admin_name))
                .ForMember(p => p.instructor, option => option.MapFrom(src => src.class_Info.instructor_info.admin_name));
            //班级信息映射
            CreateMap<class_info, class_info_dto>()
                .ForMember(p => p.class_name, option => option.MapFrom(src => src.major_Info.major_name + (src.nature ? "本" : "专") + src.grade + "级" + (src.class_number > 9 ? src.class_number.ToString() : "0" + src.class_number.ToString()) + "班" + new Type_Enum.CLASSTYPE[(int) src.additional].ToString()))
                .ForMember(p => p.headmaster, option => option.MapFrom(src => src.headmaster_info.admin_name))
                .ForMember(p => p.instructor, option => option.MapFrom(src => src.instructor_info.admin_name));
            //老师信息映射
            CreateMap<teachers, teacher_info_dto>()
                .ForMember(p => p.phone, option => option.MapFrom(src => src.phone.Substring(0, 3) + "****" + src.phone.Substring(7)))
                .ForMember(p => p.powers, option => option.MapFrom(src => new Power_Enum.TEACHER_POWER[src.powers].ToString()));
            //居住信息映射（以班级为单位）
            CreateMap<class_info, live_info_base_class_dto>()
                .ForMember(p => p.headmaster, option => option.MapFrom(src => src.headmaster_info.admin_name))
                .ForMember(p => p.instructor, option => option.MapFrom(src => src.instructor_info.admin_name))
                .ForMember(p => p.college_name, option => option.MapFrom(src => src.major_Info.college_Info.college_name))
                .ForMember(p => p.build_id, option => option.MapFrom(src => src.students_Infos.GroupBy(s => s.live_Info.room_Info.room_id)));
        }
    }
}
