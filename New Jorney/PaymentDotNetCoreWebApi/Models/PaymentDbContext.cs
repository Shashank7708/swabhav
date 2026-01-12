using Microsoft.EntityFrameworkCore;

namespace PaymentDotNetCoreWebApi.Models
{
    public class PaymentDbContext :DbContext
    {
        public PaymentDbContext(DbContextOptions options):base(options) 
        { 
        
        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }

    }
}
