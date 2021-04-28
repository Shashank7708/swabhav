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
    public class AddressController : ControllerBase
    {
        private IContactRepository _db;
        public AddressController(IContactRepository dbContext)
        {
            this._db = dbContext;
        }

        
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/register")]
        public ActionResult<Address> PostAddress(DtoAddress dtoaddress,Guid tenentId,Guid userId,Guid contactId)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address { City = dtoaddress.City,State=dtoaddress.State,Country=dtoaddress.Country };
                address.Id = new Guid();
                address.Contact = this._db.GetContactAsPerId(tenentId,userId,contactId);

                this._db.AddAddress(address);
                return Ok("Post Successfully");
            }

            return BadRequest("Post Successfull");
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address")]
        public ActionResult<IQueryable<Address>> GetAddress(Guid tenentId,Guid userId,Guid contactId)
        {
            IQueryable<Address> addresses= this._db.GetAddresss(tenentId,userId,contactId);
            if (addresses.Count() > 0)
            {
                return Ok(addresses);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}")]
        public ActionResult<Address> GetAAddress(Guid addressId,Guid tenentId,Guid contactId,Guid userId)
        {
           Address address= this._db.GetAddres(tenentId,userId,contactId,addressId);
            if (address.City != null)
            {
                return Ok(address);
            }
            return NotFound();
        }
        
        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}/edit")]
        public ActionResult PutAddress(Guid addressId, Guid tenentId, Guid contactId, Guid userId,DtoAddress dtoAddress)
        {
            if (ModelState.IsValid)
            {
                Address address = this._db.GetAddres(tenentId, userId, contactId, addressId);
                address.Country = dtoAddress.Country;
                address.State = dtoAddress.State;
                address.City = dtoAddress.City;
                bool result = this._db.UpdateAddress(address);
                if (result)
                {
                    return Ok("Successfully Updated");
                }
            }
            return BadRequest("Not Updated Successfully");
        }


        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/address/{addressId}/delete")]
        public ActionResult DeleteAddress(Guid addressId, Guid tenentId, Guid contactId, Guid userId)
        {
            bool result = this._db.DeleteAddress(addressId);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Not Deleted");

        }




    }
}
