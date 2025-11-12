using Microsoft.EntityFrameworkCore;
using FinanceAppMVC;
using FinanceAppMVC.Models;
namespace FinanceAppMVC
{
    public class FinanceAppDbContext: DbContext
    {
        public FinanceAppDbContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
