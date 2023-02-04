using Model;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public async Task<int> Creat(T Model)
        {
            return await DbScoped.SugarScope.Insertable(Model).ExecuteCommandAsync();
        }
        

        public async Task<int> Creat(List<T> Model)
        {
            return await DbScoped.SugarScope.Insertable(Model).ExecuteCommandAsync();
        }

        public async Task<int> Delete(T Model)
        {
            return await DbScoped.SugarScope.Deleteable(Model).ExecuteCommandAsync();
        }

        public async Task<int> Delete(List<T> Model)
        {
            return await DbScoped.SugarScope.Deleteable(Model).ExecuteCommandAsync();
        }

        public async Task<List<T>> GetList()
        {
            return await DbScoped.SugarScope.Queryable<T>().ToListAsync();
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> expression)
        {
            return await DbScoped.SugarScope.Queryable<T>().Where(expression).ToListAsync();
        }

        public Task<List<T>> GetList(string query)
        {
            throw new NotImplementedException();
        }

        public Task<PageData<T>> GetPageData(PageData<object> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> Updata(T Model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Updata(List<T> Model)
        {
            throw new NotImplementedException();
        }
    }
}
