using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp_data1.Repository;

namespace ContactAndAddressWebApiCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Repository1 db = new Repository1();
        [HttpGet]
        public IActionResult get()
        {
            return Ok( db.getContact());
        }



    }
}
