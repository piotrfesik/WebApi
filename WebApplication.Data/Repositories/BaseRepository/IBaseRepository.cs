using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication.Data.Repositories.BaseRepository
{
    public interface IBaseRepository<T>  where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> searchExpression);

        void Delete(T entity);

        Task AddAsync(T entity);

        Task SaveAsync();
    }
}