using ContactAddressCore.Model;
using ContactAndAddressApp_data.Repository;
using ContactAndAddressWebAPi.DtoModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.Controllers
{  
    [Route("api/v1/tenents")]
    [ApiController]
    public class TenentController : ControllerBase
    {
        private IContactRepository _db;
        public TenentController(IContactRepository dbContext)
        {
            this._db = dbContext;
        }
        [HttpPost]
       [EnableCors("CorsPolicy")]
        [Route("register")]
        public ActionResult<Tenent> AddTenet(DtoTenet dtotenent)
        {
            if (ModelState.IsValid)
            {
                Tenent tenet = new Tenent { Name = dtotenent.Name,TenentStrength=dtotenent.TenentStrength };
                tenet.Id = new Guid();
                _db.AddTenent(tenet);
                return Ok(tenet);
            }
            return BadRequest("Not added Tenent");
        }

        [HttpGet]
       [EnableCors("CorsPolicy")]
        [Route("{tenentId}/get")]
        public ActionResult<Tenent> GetTenetAsPerId(Guid tenentId)
        {
            var tenet = this._db.GetTenent(tenentId);
            if (tenet.Name != null)
            {
                return Ok(tenet);
            }
            else
            {
                return NotFound("No Such Tenet is Register");
            }
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("")]
        public ActionResult<IQueryable<Tenent>> GetTenents()
        {
            IQueryable<Tenent> tenents=this._db.GetTenents();
            if (tenents.Count() > 0)
            {
                return Ok(tenents);
            }
            else
            {
                return NoContent(); 
            }
        }

        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/delete")]
        public ActionResult DeleteTenent(Guid tenentId)
        {
            bool result = this._db.DeleteTenent(tenentId);
            
            if (result)
            {
                return Ok("Deleted Successfully");
            }
           return BadRequest("Not Deleted");
        }

        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/update")]
        public ActionResult UpdateTenent(Guid tenentId,DtoTenet dtotenent)
        {
            if (ModelState.IsValid)
            {
                Tenent tenent = this._db.GetTenent(tenentId);
                tenent.Name = dtotenent.Name;
                tenent.TenentStrength = dtotenent.TenentStrength;
                bool result = _db.UpdateTenent(tenent);
                if (result)
                {
                    return Ok("Updated successfully");
                }
            }
            return BadRequest("Not updated ");
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentname}/getIdBasedOnname")]
        public ActionResult<Tenent> GetTenetAsPerName(string tenentname)
        {
            var tenent = this._db.GetTenentbasedonName(tenentname);
            if (tenent == null)
            {
                return NotFound("No Such Tenet is Register");
            }
            else
            {
                return Ok(tenent);
            }
        }



    }
}
