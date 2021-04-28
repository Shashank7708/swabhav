using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAndAddressApp_data.Repository;
using ContactAddressCore.Model;
using Microsoft.AspNetCore.Cors;
using ContactAndAddressWebAPi.DtoModel;
using Microsoft.AspNetCore.Authorization;

namespace ContactAndAddressWebAPi.Controllers
{
  
    [Route("api/v1/tenents")]
    [ApiController]
    public class ContactController : ControllerBase
    {
      private  IContactRepository _db;
        public ContactController(IContactRepository dbContext)
        {
            this._db = dbContext;
        }
        
        
        [HttpPost] 
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/register")]
        public ActionResult<Contact> PostContact(DtoContact dtocontact,Guid tenentId,Guid userId)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact { Name = dtocontact.Name, Mobileno = dtocontact.MobileNo };
                User user = new User { Id = userId };
                contact.User = this._db.GetUser(tenentId,user);
                contact.Id = new Guid();
                this._db.AddContact(contact);
                return Ok("Posted Successfully");
            }

            return BadRequest("Not Post Successfull");
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}")]
        public ActionResult<Contact> GetContact(Guid tenentId, Guid userId, Guid contactId)
        {
            Contact contact= this._db.GetContactAsPerId(tenentId,userId,contactId);
            if (contact.Name != null)
            {
                return Ok(contact);
            }
            return NoContent();
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contacts")]
        public ActionResult<IQueryable<Contact>> GetAllContact( Guid tenentId,Guid userId)
        {
          IQueryable<Contact> contacts= this._db.GetContacts(tenentId,userId);
            if (contacts.Count() > 0)
            {
                return Ok(contacts);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/user/{userId}/contact/{contactId}/update")]
        public ActionResult UpdateContact(Guid tenetId, Guid userId, Guid contactId,DtoContact dtoupdatecontact)
        {
            if (ModelState.IsValid)
            {
                Contact contact = this._db.GetContactAsPerId(tenetId,userId,contactId);
                contact.Name = dtoupdatecontact.Name;
                contact.Mobileno = dtoupdatecontact.MobileNo;
                bool result = this._db.UpdateContact(contact);
                if (result)
                {
                    return Ok("Updated Successfully");
                }
            }
            return BadRequest("Not Updated Contact");
        }




        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/delete")]
        public ActionResult<Contact> DeleteContact(Guid tenetId, Guid userId, Guid contactId)
        {
            bool result = this._db.DeleteContact(contactId);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            return NotFound("Not Deleted Contact");
        }








    }
}
