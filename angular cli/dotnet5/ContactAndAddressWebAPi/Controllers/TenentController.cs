using ContactAddressCore.Model;
using ContactAndAddressApp_data.Repository;
using ContactAndAddressWebAPi.AuthentictionFlder;
using ContactAndAddressWebAPi.DtoModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/tenents")]
    [ApiController]
    public class TenentController : ControllerBase
    {

        private IEfRespository<Tenent> _tenentRepo;
        public TenentController(IEfRespository<Tenent> repo)
        {

            _tenentRepo = repo;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("register")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin" })]
        public async Task<ActionResult<Tenent>> AddTenet(DtoTenet dtotenent)
        {
            if (ModelState.IsValid)
            {
                Tenent tenet = new Tenent { Name = dtotenent.Name, TenentStrength = dtotenent.TenentStrength };
                tenet.Id = new Guid();

                await _tenentRepo.Add(tenet);
                return Ok(tenet);
            }
            return BadRequest("Not added Tenent");
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/get")]
        [SampleJwtAuthorization]
        public async Task<ActionResult<Tenent>> GetTenetAsPerId(Guid tenentId)
        {
            var tenet = await this._tenentRepo.GetById(tenentId);
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
        [SampleJwtAuthorization(Role = new string[] { "superadmin" })]
        public async Task<ActionResult<IEnumerable<Tenent>>> GetTenents()
        {
            IEnumerable<Tenent> tenents = await this._tenentRepo.GetAll();
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
        [SampleJwtAuthorization(Role = new string[] { "superadmin" })]
        public async Task<ActionResult> DeleteTenent(Guid tenentId)
        {
            if (await this._tenentRepo.GetById(tenentId) != null)
            {
                Tenent tenent = await this._tenentRepo.GetById(tenentId);
                await this._tenentRepo.Remove(tenent);
                return Ok("Deleted Successfully");
            }

            return BadRequest("Not Deleted");
        }

        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/update")]
        [SampleJwtAuthorization(Role =new string[] { "superadmin" })]
        public async  Task<ActionResult> UpdateTenent(Guid tenentId,DtoTenet dtotenent)
        {
            if (ModelState.IsValid  && (await this._tenentRepo.GetById(tenentId)!=null))
            {
                Tenent tenent = await this._tenentRepo.GetById(tenentId);
                tenent.Name = dtotenent.Name;
                tenent.TenentStrength = dtotenent.TenentStrength;
                await this._tenentRepo.update(tenent);
                
                    return Ok("Updated successfully");
                
            }
            return BadRequest("Not updated ");
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentname}/getIdBasedOnname")]
        public async Task<ActionResult<Tenent>> GetTenetAsPerName(string tenentname)
        {
            var tenent =await this._tenentRepo.FirstOrDefault(x=>x.Name==tenentname);
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
