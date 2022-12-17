using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class.Result_Help
{
    public class Http_Helper<T> where T : class, new()
    {
        public Http_Help<T> Succeed(string message, T value) => new Http_Help<T>() { Code = 200, Message = message, data = value };
        public Http_Help<T> Warming(string message) => new Http_Help<T>() { Code = 400, Message = message, };
    }
}
