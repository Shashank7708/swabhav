using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactAndAddressApp_data.Repository
{
  public  interface IEfRespository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicated);

        Task Add(T entity);
        Task update(T entity);
        Task Remove(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetListBasedOnCondition(Expression<Func<T, bool>> predicate);


    }

}
