using Microsoft.EntityFrameworkCore;

namespace EventManagementWebApi.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) { }

        public DbSet<UserMaster> userMaster { get; set; }
        public DbSet<EventMaster> EventMaster { get; set; }
        public DbSet<BookingMaster> BookingMaster { get; set; }
        
    }
}
