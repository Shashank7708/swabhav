namespace RestaurantAppMVC.Repository
{
    public interface IRespository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, QueryOptions<T> options=null);
        Task<bool> AddAsync(T entity);
        Task<bool > UpdateAsync(T entity);
        Task<bool> DeleteAsync (T entity );
    }
}
