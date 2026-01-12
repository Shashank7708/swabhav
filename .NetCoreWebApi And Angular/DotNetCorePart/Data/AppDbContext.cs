using DotNetCorePart.Model;
using Microsoft.EntityFrameworkCore;


namespace DotNetCorePart.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { 
        }
        public DbSet<Product> Product { get; set; }
    }
}
