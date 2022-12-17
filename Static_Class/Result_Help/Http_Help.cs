using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class.Result_Help
{
    public class Http_Help<T> where T : class, new()
    {
        public int Code{get; set;}
        public string? Message{get; set;}
        public T? data{get; set;}
    }
}
