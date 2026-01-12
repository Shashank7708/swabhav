using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.DtoModel
{
    public class DtoContact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int MobileNo { get; set; }

    }
}
