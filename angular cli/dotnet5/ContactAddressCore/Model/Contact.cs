using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactAddressCore.Model
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Mobileno { get; set; }
       
        public virtual User User { get; set; }

        public virtual List<Address> Address { get; set; } = new List<Address>();
    }
}
