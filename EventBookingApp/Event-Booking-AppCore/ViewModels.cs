using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Booking_AppCore
{
    public class UserRegisterDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    public class UserLoginDto
    {
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int UserId { get; set; } 

        // public string RefreshToken { get; set; }
    }
    public class EventMasterViewModel
    {
        public Guid id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string venueName { get; set; } = null!;
        public int capacity { get; set; }
        public string? imageUrl { get; set; } //= null!;
        public decimal price { get; set; }
        public bool isActive { get; set; }
        public string createdBy { get; set; } = null!;
        public DateTime createdOn { get; set; }
    }
    public class BookingMasterViewModel 
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public Guid EventId { get; set; }
        public string Status { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        // [JsonIgnore]
        public  string EventName { get; set; } = null!;
    }
    public class EventBookingViewModel()
    {
        public int BookingId { get; set; }
        public Guid EventId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public string EventTitle { get; set; } = null!;
        public string EventVenue { get; set; } = null!;
        public string EventDescription { get; set; } = null!;
        public DateTime EventStartDate { get; set; } 
        public DateTime EventEndDate { get; set; } 
        public decimal EventPrice { get; set; } 

    }

    public class ConfirmBookingRequest
    {
        public int UserId { get; set; }
        public Guid EventId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
