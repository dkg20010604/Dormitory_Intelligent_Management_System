using System.Security.Cryptography;
using System.Text;

namespace Static_Class
{
    public class MD5_Services
    {
        public static string GenerateMD5(string paw)
        {
            using MD5 mi = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(paw);
            //开始加密
            byte[] newBuffer = mi.ComputeHash(buffer);
            StringBuilder sb = new();
            for (int i = 0;i < newBuffer.Length;i++)
            {
                sb.Append(newBuffer[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
