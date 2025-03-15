using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepositoryBase <T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll(bool v);
        Task<T> GetById(Expression<Func<T, bool>> predicate,bool v);
        Task Update (T entity);


    }
}
