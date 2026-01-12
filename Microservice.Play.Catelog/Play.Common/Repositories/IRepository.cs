

using Play.Common.Entities;
using System.Linq.Expressions;

namespace Play.Common.Repositories
{
    public interface IRepository<T> where T:IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T,bool >> filter);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}