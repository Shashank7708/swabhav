using ContactAddressCore.Model;
using ContactAndAddressApp_data.Repository;
using ContactAndAddressWebAPi.DtoModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.Controllers
{
   
    [Route("api/v1/tenents")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IContactRepository _db;
        public UserController(IContactRepository dbContext)
        {
            this._db = dbContext;
        }

       
        [HttpPost]
        [Route("{tenentId}/user/register")]
        [EnableCors("CorsPolicy")]
        public ActionResult<User> AddUser(DtoUser dtouser, string tenentId)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = dtouser.UserName, Password = dtouser.Password, Role = dtouser.Role };
                user.Id = new Guid();
                user.Tenent = _db.GetTenent(Guid.Parse(tenentId));
                this._db.AddUser(user);
                return Ok(user);
            }
            return BadRequest("Not Posted User");
        }
     
        [HttpGet]
        [Route("{tenentId}/user/{username}/{password}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<User> GetUserAsPerId(string tenentId,string username,string password)
        {
            //EncryptAndDecrypt.ConvertToDecrypt(password)
            User validateUser = new User { UserName =username, Password =password };
            var user = this._db.GetUser(Guid.Parse(tenentId),validateUser);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("No Such Tenet is Register");
            }
            
        }

        [HttpGet]
        [Route("{tenentId}/user")]
        [EnableCors("CorsPolicy")]
        public ActionResult<IQueryable<User>> GetUsersOfATenent(Guid tenentId)
        {
            IQueryable<User> users=this._db.GetUsers(tenentId);
            if (users.Count()>0)
            {
                return Ok(users);
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{tenentId}/user/{userId}/update")]
        [EnableCors("CorsPolicy")]
        public ActionResult UpdateUser(Guid tenentId, Guid userId,DtoUser usertobeupdated)
        {
            try
            {
                if (ModelState.IsValid)
                { User userToCheckIfExist = new User { Id = userId };
                    var user = this._db.GetUser(tenentId, userToCheckIfExist);
                    user.UserName = usertobeupdated.UserName;
                    user.Password = usertobeupdated.Password;
                    user.Role = usertobeupdated.Role;
                    bool result = this._db.UpdateUser(user);
                    if (result)
                    {
                        return Ok("User is Updated Successfully");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest("Usr not Updated");
            }
            return BadRequest("User not Updated");
        }


        [HttpDelete]
        [Route("{tenentId}/user/{userId}/delete")]
        [EnableCors("CorsPolicy")]
        public ActionResult DeleteUser(Guid tenentId,Guid userId)
        {
            try
            {
                bool result = this._db.DeleteUser(userId);
                if (result)
                {
                    return Ok("User is deleted Successfully");
                }
            
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest("Usr not deleted");
    }
            return BadRequest("User not deleted");
}


    }
}
