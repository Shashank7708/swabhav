
using EventManagementWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventManagementWebApi.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,new()
    {
        private readonly MyDbContext _context;
        private DbSet<T> _dbSet;
        private readonly IAppLogger _logger;
        public GenericRepository(MyDbContext context, IAppLogger logger)
        {
            _dbSet = context.Set<T>();
            _context= context;
        }
        public async Task<bool> AddAsync(T obj)
        {
            try { 
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return false;
            }
        }

        public  bool Delete(T obj)
        {
            try { 
             _dbSet.Remove(obj);
            // _context.SaveChanges();
            return true;
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return false;
            }
        }
        public async Task SaveChangesAsycn()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includes != null)
                {
                    foreach (var i in includes)
                    {
                        query = query.Include(i);
                    }
                }
                var abc= await query.ToListAsync();
                return abc;
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return null;
            }
}

        public async Task<T> GetAsyncBasedOnId( Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes) 
        {
            try {
                T item = new T(); ;
                IQueryable<T> query = _dbSet;
                if (includes != null)
                {
                    foreach (var i in includes)
                    {
                        query = query.Include(i);
                    }
                }
                if (filter != null)
                    item = await _dbSet.FirstOrDefaultAsync(filter);
                if (item == null)
                    return new T();
                return item;
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return null ;
            }
        }

       

        public bool Update(T obj)
        {
            try
            {
                _dbSet.Update(obj);
                //  _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return false;
            }
}
    }
}
