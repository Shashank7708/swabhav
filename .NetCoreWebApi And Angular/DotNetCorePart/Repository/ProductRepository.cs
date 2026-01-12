using DotNetCorePart.Data;
using DotNetCorePart.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePart.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        { 
            try
            {
                var list =await  _context.Product.ToListAsync();
                
                return list;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<Product> GetProductOnId(int id)
        {
            var product = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product == null) 
                return null;
            return product;
        }
        public async Task<bool> AddProduct(Product p)
        {
            await _context.Product.AddAsync(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
