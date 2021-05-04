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
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   // [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin", "normal", "user" })]
    [Route("api/v1/tenents")]
    [ApiController]
    public class AddressController : ControllerBase
    {
       
        private IEfRespository<Contact> _contactrepo;
        private IEfRespository<Address> _addressrepo;
        public AddressController(IEfRespository<Contact> contactrepo,IEfRespository<Address> addressrepo)
        {
            
            this._contactrepo = contactrepo;
            this._addressrepo = addressrepo;
        }

        
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/register")]
        public async Task<ActionResult> PostAddress(DtoAddress dtoaddress,Guid tenentId,Guid userId,Guid contactId)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address { City = dtoaddress.City,State=dtoaddress.State,Country=dtoaddress.Country };
                address.Id = new Guid();
                address.Contact = await this._contactrepo.FirstOrDefault(x => x.Id ==contactId && x.User.Id == userId && x.User.Tenent.Id==tenentId);


               await this._addressrepo.Add(address);
                return Ok("Post Successfully");
            }

            return BadRequest("Post Successfull");
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address")]
        public async Task<ActionResult<List<Address>>> GetAddress(Guid tenentId,Guid userId,Guid contactId)
        {
            if (await _contactrepo.FirstOrDefault(x => x.Id == contactId && x.User.Id == userId && x.User.Tenent.Id == tenentId) == null)
                return BadRequest("not found");
            List<Address> addresses=(await this._addressrepo.GetListBasedOnCondition(x=>x.Contact.Id==contactId && x.Contact.User.Id==userId
                                                                                        && x.Contact.User.Tenent.Id==tenentId)).ToList();
            
                return addresses;
            
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}")]
        public async Task<ActionResult<Address>> GetAAddress(Guid addressId,Guid tenentId,Guid contactId,Guid userId)
        {
           Address address=await this._addressrepo.FirstOrDefault(x=>x.Id==addressId && x.Contact.Id==contactId
                                                                     && x.Contact.User.Id==userId && x.Contact.User.Tenent.Id==tenentId);
            if (address != null)
            {
                return Ok(address);
            }
            return NotFound();
        }
        
        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}/edit")]
        public async Task<ActionResult> PutAddress(Guid addressId, Guid tenentId, Guid contactId, Guid userId,DtoAddress dtoAddress)
        {
            if (ModelState.IsValid && (await this._addressrepo.FirstOrDefault(x => x.Id == addressId && x.Contact.Id == contactId
                                                                       && x.Contact.User.Id == userId && x.Contact.User.Tenent.Id == tenentId))!=null)
            {
                Address address = await this._addressrepo.FirstOrDefault(x => x.Id == addressId && x.Contact.Id == contactId
                                                                      && x.Contact.User.Id == userId && x.Contact.User.Tenent.Id == tenentId);

                address.Country = dtoAddress.Country;
                address.State = dtoAddress.State;
                address.City = dtoAddress.City;
                await this._addressrepo.update(address);
                return Ok("Successfully Updated");
               
            }
            return BadRequest("Not Updated Successfully");
        }


        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}/delete")]
        public async Task<ActionResult> DeleteAddress(Guid addressId, Guid tenentId, Guid contactId, Guid userId)
        {
            
            if (await this._addressrepo.FirstOrDefault(x => x.Id == addressId && x.Contact.Id == contactId
                                                                        && x.Contact.User.Id == userId && x.Contact.User.Tenent.Id == tenentId)!= null)
            {
                Address address = await this._addressrepo.FirstOrDefault(x => x.Id == addressId && x.Contact.Id == contactId
                                                                          && x.Contact.User.Id == userId && x.Contact.User.Tenent.Id == tenentId);
                await this._addressrepo.Remove(address);
                return Ok("Deleted Successfully");
            }
            return BadRequest("Not Deleted");

        }




    }
}
