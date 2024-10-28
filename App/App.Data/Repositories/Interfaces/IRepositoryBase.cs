using System.Linq.Expressions;

namespace App.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
