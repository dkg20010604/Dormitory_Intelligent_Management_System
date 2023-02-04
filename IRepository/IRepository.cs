using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal interface IRepository<T> where T : class, new()
    {
        Task<int> Creat(T Model);

        Task<int> Creat(List<T> Model);

        Task<int> Updata(T Model);

        Task<int> Updata(List<T> Model);

        Task<int> Delete(T Model);

        Task<int> Delete(List<T> Model);

        Task<PageData<T>> GetPageData(PageData<object> data);

        Task<List<T>> GetList();

        Task<List<T>> GetList(Expression<Func<T, bool>> expression);

        Task<List<T>> GetList(string query);
    }
}
