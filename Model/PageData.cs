namespace Model
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 数据总量
        /// </summary>
        public int DataTotal { get; set; }
        /// <summary>
        /// 每一页的数据量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string? quary{get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T>? Data { get; set; }
    }
}
