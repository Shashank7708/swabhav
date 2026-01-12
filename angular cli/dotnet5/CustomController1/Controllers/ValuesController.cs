using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomController1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Rohan", "Vishal", "Sumit", "Shashank" };
        }

        [HttpGet("{id")]
        public string Get(int id)
        {
            return "The Id is" + id;
        }

    }
}
