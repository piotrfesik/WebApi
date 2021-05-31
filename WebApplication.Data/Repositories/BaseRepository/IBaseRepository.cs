using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication.Data.Repositories.BaseRepository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();

        Task<IQueryable<T>> FindByIdAsync(int id);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> searchExpression);

        void Delete(T entity);

        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        Task SaveAsync();

        void Save();

        void Detached(T entity);
    }
}