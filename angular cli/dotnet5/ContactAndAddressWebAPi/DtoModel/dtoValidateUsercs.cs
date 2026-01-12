using ContactAddressCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.DtoModel
{
    public class dtoValidateUsercs
    {   
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
        
        public string Token { get; set; }
        public Guid Tenentid { get; set; }
    }
}
