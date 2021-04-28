using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAndAddressWebAPi.DtoModel;
using ContactAddressCore.Model;
using ContactAndAddressApp_data.Repository;
using ContactAndAddressWebAPi.Service;
using Microsoft.AspNetCore.Cors;

namespace ContactAndAddressWebAPi.Controllers
{   /*
    [Route("api/authenticate")]
    
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticatservice;
        public AuthenticationController(IAuthenticateService service)
        {
            _authenticatservice = service;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public IActionResult Post([FromBody] DtoUser dtouser)
        {
            var user = _authenticatservice.Authenticate(dtouser.UserName, dtouser.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or Password in Incorrect" });
            }
            return Ok(user);
        }
        
    }
    */
}
    