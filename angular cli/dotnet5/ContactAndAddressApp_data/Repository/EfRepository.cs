using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ContactAndAddressApp_data.Repository
{
   public class EfRepository<T> : IEfRespository<T> where T : class
    {
        protected ContactDbContext Context;
      
        public EfRepository(ContactDbContext db)
        {
            Context = db;
        }


        public async Task<T> GetById(Guid id) =>await Context.Set<T>().FindAsync(id);

        public  Task<T> FirstOrDefault(Expression<Func<T, bool>> predicated) =>
                                      Context.Set<T>().FirstOrDefaultAsync(predicated);
        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListBasedOnCondition(Expression<Func<T,bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

       



      

    }
}
