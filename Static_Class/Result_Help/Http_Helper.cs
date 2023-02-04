namespace Static_Class.Result_Help
{
    public class Http_Helper<T>
    {
        public Http_Help<T> Succeed(string message, T value) => new Http_Help<T>() { Code = 200, Message = message, data = value };
        public Http_Help<T> Warming(string message) => new Http_Help<T>() { Code = 400, Message = message, };
        public Http_Help<T> Error(string message) => new Http_Help<T>() { Code = 500, Message = message, };
    }
    public class Http_Help<T>
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }
}
