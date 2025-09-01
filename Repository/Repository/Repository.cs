using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly MyDbContext _dbContext;
        
        public Repository(MyDbContext dbContext)
        {   
            _dbSet=dbContext.Set<T>();
            _dbContext = dbContext;

        }
        public async Task<T> AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var obj =await _dbSet.FindAsync(id);
            return obj;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State=EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
