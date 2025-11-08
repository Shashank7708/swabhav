
using Microsoft.EntityFrameworkCore;

namespace WebApiProduct.Repository
{
    public class MyRepository<T> : IRepository<T> where T : class
    {   private readonly MyDbContext _dbContext;
        protected DbSet<T> _dbSet;
        public MyRepository(MyDbContext myDbContext)
        {
            _dbSet=myDbContext.Set<T>();
            this._dbContext = myDbContext;
        }

        public async Task<bool> AddAsync(T obj)
        {
            await this._dbSet.AddAsync(obj);
            await this._dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T obj)
        {
             this._dbSet.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;
        }            

        public async Task<IList<T>> GetAllAsycn()
        {
            var items =await this._dbSet.ToListAsync();
            return items;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item = await this._dbSet.FindAsync(id);
            return item;
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            this._dbSet.Update(obj);
            //this._dbContext.Entry(T).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            return true;
        }
    }
}
