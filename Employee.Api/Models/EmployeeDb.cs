using Employee.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Employee.Api.Models
{
    public class EmployeeDb
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string EmailId { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(8)]
        public string ContactNo { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }

    }
}

