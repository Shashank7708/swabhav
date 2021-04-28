using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.DtoModel
{
    public class DtoTenet
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int TenentStrength { get; set; }

    }
}
