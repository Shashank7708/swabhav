using Event_Booking_AppCore;
using Microsoft.EntityFrameworkCore;

namespace EventBookingAppNew.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<UserMaster> userMaster { get; set; }
        public DbSet<EventMaster> EventMaster { get; set; }
        public DbSet<BookingMaster> BookingMaster { get; set; }
    }
}
