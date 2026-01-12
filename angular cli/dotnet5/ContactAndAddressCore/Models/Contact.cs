using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAndAddressCore.Models
{   [Table("Contact")]
   public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int mobileno { get; set; }

        public virtual List<Address> address { get; set; } = new List<Address>();
    }
}
