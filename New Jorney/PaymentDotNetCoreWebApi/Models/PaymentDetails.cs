using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentDotNetCoreWebApi.Models
{
    public class PaymentDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(180)")]
        public string CardOwnerName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string ExpiryDate { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string CVV { get; set; }
    }
}
