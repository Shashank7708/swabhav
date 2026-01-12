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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ContactAndAddressWebAPi.AuthentictionFlder;

namespace ContactAndAddressWebAPi.Controllers
{
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/v1/tenents")]
    [ApiController]
  //  [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin","normal","user" })]
    public class ContactController : ControllerBase
    {
      
        private IEfRespository<Tenent> _tenentRepo;
        private IEfRespository<User> _userRepo;
        private IEfRespository<Contact> _contactRepo;
        public ContactController(IEfRespository<Tenent> tenentRepo, IEfRespository<User> userrepo,IEfRespository<Contact> contactrepo)
        {
            
            this._tenentRepo = tenentRepo;
            this._userRepo = userrepo;
            this._contactRepo = contactrepo;
        }
        
        
        [HttpPost] 
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/register")]
        public async Task<ActionResult> PostContact(DtoContact dtocontact,Guid tenentId,Guid userId)
        {
            if (await _userRepo.FirstOrDefault(x => x.Tenent.Id == tenentId && x.Id == userId) == null)
                return BadRequest("tenent or user not found");
            if (ModelState.IsValid)
            {
                Contact contact = new Contact { Name = dtocontact.Name, Mobileno = dtocontact.MobileNo };
                User user = new User { Id = userId };
                contact.User =await this._userRepo.FirstOrDefault(x=>x.Tenent.Id==tenentId && x.Id==userId);
                contact.Id = new Guid();
                await this._contactRepo.Add(contact);
                return Ok("Posted Successfully");
            }

            return BadRequest("Not Post Successfull");
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}")]
        public async Task<ActionResult<Contact>> GetContact(Guid tenentId, Guid userId, Guid contactId)
        {
            Contact contact=await this._contactRepo.FirstOrDefault(x=>x.Id==contactId && x.User.Id==userId && x.User.Tenent.Id==tenentId);
            if (contact.Name != null)
            {
                return Ok(contact);
            }
            return NoContent();
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contacts")]
        public async Task<ActionResult<List<Contact>>> GetAllContact( Guid tenentId,Guid userId)
        {
            if (await _tenentRepo.GetById(tenentId) == null)
                return BadRequest("tenent not found");
            if (await _userRepo.GetById(userId) == null)
                return BadRequest("user not found");
          List<Contact> contacts=(await this._contactRepo.GetListBasedOnCondition(
                                                          x=>x.User.Tenent.Id==tenentId &&
                                                          x.User.Id==userId)).ToList();
            
                return contacts;
           
        }

        [HttpPut]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/user/{userId}/contact/{contactId}/update")]
        public async  Task<ActionResult> UpdateContact(Guid tenetId, Guid userId, Guid contactId,DtoContact dtoupdatecontact)
        {   if (await _tenentRepo.GetById(tenetId) == null)
                return BadRequest("tenent not found");
            if (await _userRepo.GetById(userId) == null)
                return BadRequest("user not found");
            if (await _contactRepo.GetById(contactId) == null)
                return BadRequest("contact not found");

            if (!ModelState.IsValid)
                return BadRequest("Information provided is not valid");
            
                Contact contact = await this._contactRepo.FirstOrDefault(x => x.Id == contactId && x.User.Id == userId);
                contact.Name = dtoupdatecontact.Name;
                contact.Mobileno = dtoupdatecontact.MobileNo;
                await this._contactRepo.update(contact);
                return Ok("Updated Successfully");
            
        }




        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("{tenentId}/users/{userId}/contact/{contactId}/delete")]
        public async Task<ActionResult> DeleteContact(Guid tenetId, Guid userId, Guid contactId)
        {
            if(await this._contactRepo.FirstOrDefault(x=>x.Id==contactId && x.User.Id==userId) != null)
            {
                Contact contact = await this._contactRepo.FirstOrDefault(x => x.Id == contactId && x.User.Id == userId);
                await this._contactRepo.Remove(contact);
                return Ok("Deleted Successfully");
            }
            return NotFound("Not Deleted Contact");
        }








    }
}
