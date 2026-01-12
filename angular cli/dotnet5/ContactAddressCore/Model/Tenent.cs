using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactAddressCore.Model
{   [Table("Tenent")]
   public class Tenent
    {
        [Key]
        public Guid Id { get; set; }
     
        public string Name { get; set; }

       public int TenentStrength { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();



    }
}
