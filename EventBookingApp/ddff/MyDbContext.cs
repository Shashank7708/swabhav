using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ddff
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EventMaster> EventMaster { get; set; }
        public DbSet<BookingMaster> BookingMaster { get; set; }

    }
    public interface IAudit
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
    public class EventMaster : IAudit
    {
        public EventMaster()
        {
           // Bookings = new List<BookingMaster>();
        }
        [Key]
        public Guid id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? VenueName { get; set; }
        public int Capacity { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
       // public virtual ICollection<BookingMaster> Bookings { get; }
    }


    public class BookingMaster : IAudit
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        // public Guid EventId { get; set; } 
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        // public virtual EventMaster EventMaster { get; set; } 
    }
}
