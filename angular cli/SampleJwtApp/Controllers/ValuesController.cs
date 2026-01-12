using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SampleJwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private ICustomTokenManager tokenManager;

        public ValuesController(ICustomTokenManager tokenManage)
        {
            this.tokenManager = tokenManage;
        }
        [Route("/many")]
        [HttpGet]
        [SampleJwtAuthorization(Role = "Admin")]
       // [ServiceFilter(typeof(CustomAuthorization))]
        public ActionResult GetAllValues() {

            return Ok("Get called");
        }

        [Route("/single")]
        [HttpGet]
        public ActionResult GetOneValue()
        {

            return Ok("Get one called");
        }


        [HttpPost]

        [Route("/auth")]
        public ActionResult Authenitcate(string name,string pwd) {

            if (name.Equals(pwd)) {

                var token = tokenManager.CreateToken(name);

                return Ok(token);
               
            }


            return BadRequest();
        }


    }
}
