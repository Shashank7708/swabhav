using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ContactAddressCore.Model
{   [Table("User")]
   public class User
    {   [Key]
        public Guid Id { get; set; }
       
        public string UserName { get; set; }
       
        public string Password { get; set; }

        public string Role { get; set; }

        [JsonIgnore]
        public virtual Tenent Tenent { get; set; }

        
        [JsonIgnore]
        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();






    }
}
