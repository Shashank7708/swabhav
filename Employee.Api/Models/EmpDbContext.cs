using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Models
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeDb> Employee_Master { get; set; }

    }
}
