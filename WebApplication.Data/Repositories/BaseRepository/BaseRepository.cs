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
        
        private bool _isDisposed;

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

        public virtual async Task<IQueryable<T>> FindByIdAsync(int id)
        {
            return await Task.FromResult(_context.Set<T>().Where(x => x.GetType().GetProperty("Id").GetValue(x).ToString() == id.ToString()).AsQueryable());
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> searchExpression)
        {
            return _context.Set<T>().Where(searchExpression).AsQueryable();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public virtual void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (ApplicationException ex)
            {
                Debug.WriteLine(ex);
            }
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


        public virtual void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (ApplicationException ex)
            {
                Debug.WriteLine(ex);
            }
        }


        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (ApplicationException ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public virtual void Detached(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
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

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;
            _isDisposed = true;
            if (!isDisposing) return;
            _context?.Dispose();
        }
    }
}