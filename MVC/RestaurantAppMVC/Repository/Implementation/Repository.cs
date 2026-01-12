
using Microsoft.EntityFrameworkCore;
using RestaurantAppMVC.Data;

namespace RestaurantAppMVC.Repository
{
    public class Repository<T> : IRespository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private DbSet<T> _dbSet;    
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet =context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options=null)
        {
            IQueryable<T> query = _dbSet;
            if (options != null)
            {
                if (options.GetIncludes().Any())
                {
                    foreach(var i in options.GetIncludes())
                        query=query.Include(i);
                }
                if (options.HasWhere)
                {
                    query = query.Where(options.where);
                }
                if (options.HasOrderBy)
                {
                    query = query.OrderBy(options.OrderBy);
                }

            }
            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKey = key?.Name;
            var result= await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKey)==id);
            return result;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
