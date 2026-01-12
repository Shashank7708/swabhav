using EventManagementWebApi.Dto;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace EventManagementWebApi.Data
{
    public interface  IAudit
    {
         string CreatedBy { get; set; }
         DateTime CreatedOn { get; set; }
    }
    public class UserMaster : IAudit
    {
        [Key]
        public int id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set ; }

        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? username { get; set; }  
        public string?  pwd { get; set; }
        public string? role { get; set; }

    }

    public class EventMaster : IAudit
    {
        
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
        public virtual List<BookingMaster> Bookings { get; set; }=new List<BookingMaster>(){ };
    }


    public class BookingMaster:IAudit
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(EventMaster))]
        public Guid? EventId { get; set; } 
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
       // [JsonIgnore]
        public virtual EventMaster? EventMaster { get; set; } 
    }
    public class EventCategory :IAudit
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set ; }
        public DateTime CreatedOn { get ; set; }
    }
    

}
