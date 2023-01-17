using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOModels
{
    public class live_info_base_class_dto
    {
        public int build_id { get; set; }
        public int room_number { get; set; }
        public string college_name { get; set; }
        public int gread { get; set; }
        public string class_name { get; set; }
        public int full_number { get; set; }
        public int empty_number { get; set; }
        public string empty_list { get; set; }
        public string room_master { get; set; }
        public string headmaster { get; set; }
        public string instructor { get; set; }
        public List<student_base_info_dto> students { get; set; }
    }
}
