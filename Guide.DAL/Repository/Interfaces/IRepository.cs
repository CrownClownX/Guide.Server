using Guide.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guide.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetWithThrow(Expression<Func<T, bool>> predicate);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllWithPaging<U>(QueryDate<T, U> queryData);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<T> AddWithResult(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
