using DotNetCorePart.Model;

namespace DotNetCorePart.Repository
{
    public interface IProductRepository
    {
         Task<List<Product>> GetProducts();
         Task<Product> GetProductOnId(int id);
         Task<bool> AddProduct(Product p);
    }
}
