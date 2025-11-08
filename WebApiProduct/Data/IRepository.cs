namespace WebApiProduct.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsycn();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync (T obj );
        Task<bool> DeleteAsync (T obj);
    }
}
