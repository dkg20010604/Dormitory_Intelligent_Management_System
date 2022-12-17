namespace Static_Class.Result_Help
{
    public class Http_Help<T>
    {
        public int Code{get; set;}
        public string? Message{get; set;}
        public T? data{get; set;}
    }
}
