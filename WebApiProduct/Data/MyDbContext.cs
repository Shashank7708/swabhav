using Microsoft.EntityFrameworkCore;
using WebApiProduct.Data;

namespace WebApiProduct.Repository
{
    public sealed class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog>  Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.ProductId);
        }
            
    }
}
