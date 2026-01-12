using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Booking_AppCore
{
    public interface IAudit
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
    public class UserMaster : IAudit
    {
        [Key]
        public int Id { get; set; }
        public string EmailId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; } = null!;

    }
    public class EventMaster : IAudit
    {

        [Key]
        public Guid id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VenueName { get; set; } = null!;
        public int Capacity { get; set; }
        public string? ImageUrl { get; set; } //= null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual List<BookingMaster> Bookings { get; set; } = new List<BookingMaster>() { };
    }


    public class BookingMaster : IAudit
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(EventMaster))]
        public Guid EventId { get; set; }
        public string Status { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        // [JsonIgnore]
        public virtual EventMaster EventMaster { get; set; } = null!;
    }
    public class EventCategory : IAudit
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }


}
