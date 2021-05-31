using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Context;

namespace WebApplication.Data.Repositories.BaseRepository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected virtual ApplicationDbContext DbContext
        {
            get => _context;
            set => _context = value;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> searchExpression)
        {
            return _context.Set<T>().Where(searchExpression).AsQueryable();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (ApplicationException ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public virtual async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (ApplicationException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}