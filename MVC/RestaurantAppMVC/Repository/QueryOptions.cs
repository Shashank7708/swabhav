using System.Linq.Expressions;

namespace RestaurantAppMVC.Repository
{
    public class QueryOptions<T> where T : class
    {
        public Expression<Func<T, object>> OrderBy { get; set; } = null!;
        public Expression<Func<T,bool>> where { get; set; } = null!;    
        private string[] includes=Array.Empty<string>(); 
        public string Includes
        {
            set { includes = value.Replace(" ", "").Split(','); }
        }
        public string[] GetIncludes() { 
            return includes;
        }
        public bool HasWhere { 
            get { 
                return where != null;
            } 
        }
        public bool HasOrderBy { 
            get { 
                return OrderBy != null;
            } 
        }

    }
}