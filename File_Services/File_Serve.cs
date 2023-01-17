using Dm;
using NPOI.Util;
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
        public byte[] Changeroom()
        {
            string path = BaseAddress + "调宿模板.docx";
            var Chang = _Chang;
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

    }
}
