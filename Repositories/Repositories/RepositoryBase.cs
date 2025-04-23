using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>  where T : class,new()
    {
       private readonly ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
             await _context.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
             _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll(bool v)
        {
            return !v ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }

        public async  Task<T> GetById(Expression<Func<T, bool>> predicate, bool v)
        {
            return v ?  await _context.Set<T>().Where(predicate).AsNoTracking().FirstOrDefaultAsync() : await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public IQueryable<T> GetByConditionToPaged(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate); // Koşula uyan veriyi döndürür
        }
    }
}
