using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactAddressCore.Model
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
     [Required]
        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
