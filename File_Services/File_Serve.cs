using OfficeIMO.Word;
using Static_Class;
namespace File_Services
{
    public class File_Serve
    {
        private static readonly string BaseAddress = @"D:\编程文件\Dormitory_Intelligent_Management_System\File_Services\File\";
        private static readonly Dictionary<string, string> _Chang = Template.Chengeroom();
        private static readonly Dictionary<string, string> _Back = Template.Backlive();
        private static readonly Dictionary<string, string> _Retreat = Template.Retreat();
        private static readonly Dictionary<string, string> _Endout = Template.Endout();
        /// <summary>
        /// 换宿申请文档
        /// </summary>
        /// <returns></returns>
        public byte[] Changeroom()
        {
            var Chang = _Chang;
            
            #region 查询内容并构造 Chang

            #endregion
            string path = BaseAddress + "调宿模板.docx";
            WordDocument newdoc = WordDocument.Load(path);
            using (newdoc)
            {
                var table = newdoc.Tables[0];
                for (int row = 0;row < table.Rows.Count;row++)
                {
                    for (int cell = 0;cell < table.Rows[row].Cells.Count;cell++)
                    {
                        for (int para = 0;para < table.Rows[row].Cells[cell].Paragraphs.Count;para++)
                        {
                            foreach (var dic in Chang)
                            {
                                if (table.Rows[row].Cells[cell].Paragraphs[para].Text.Contains(dic.Key))
                                {
                                    table.Rows[row].Cells[cell].Paragraphs[para].Text = table.Rows[row].Cells[cell].Paragraphs[para].Text.Replace(dic.Key, dic.Value);
                                }
                            }
                        }
                    }
                }
                newdoc.Save("xiugai.docx");
            }
            return File.ReadAllBytes("xiugai.docx");
        }

        //public byte[] college_live_info(int collegeid)
        //{
        //    var info = DbScoped.SugarScope
        //        .Queryable<live_info_build>()
        //        .SplitTable(s => s)
        //        .Includes(t => t.students_Info, s => s.class_Info, c => c.major_Info)
        //        .Where(n => n.student_id != null && n.students_Info.class_Info.major_Info.college_id == collegeid)
        //        .ToList();

        //}
    }
}
