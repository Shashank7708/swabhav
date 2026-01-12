using System.Linq.Expressions;

namespace EventManagementWebApi.Data
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsyncBasedOnId(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
        
        Task<bool> AddAsync(T obj);
        bool Delete(T obj);
        bool Update(T obj);
        Task SaveChangesAsycn();

    }
}
