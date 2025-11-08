using Microsoft.EntityFrameworkCore;
using RestaurantTableBookingApp.Core;

namespace RestaurantTableBookingApp.Data
{
    public class RestaurantTableBookingDbContext: DbContext
    {
        public RestaurantTableBookingDbContext(DbContextOptions<RestaurantTableBookingDbContext> options):base(options)
        {
        }
        public virtual DbSet<DiningTable> DiningTables { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Restaurant> Restaurants { get; set; }

        public virtual DbSet<RestaurantBranch> RestaurantBranches { get; set; }

        public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
}
