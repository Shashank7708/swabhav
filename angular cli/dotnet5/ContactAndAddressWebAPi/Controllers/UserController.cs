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
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.Controllers
{
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/tenents")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ICustomTokenManager _tokenManager;
        private IEfRespository<Tenent> _tenentRepo;
        private IEfRespository<User> _Userrepo;
        public UserController(ICustomTokenManager tokenManager,IContactRepository dbContext, IEfRespository<User> userrepo, IEfRespository<Tenent> tenentRepo)
        {
            _tokenManager = tokenManager;
            _tenentRepo = tenentRepo;
            _Userrepo = userrepo;
        }

       
        [HttpPost]
        [Route("{tenentId}/user/register")]
        [EnableCors("CorsPolicy")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult<User>> AddUser(DtoUser dtouser, Guid tenentId)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = dtouser.UserName, Password = dtouser.Password, Role = dtouser.Role };
                user.Id = new Guid();
                user.Tenent =await this._tenentRepo.GetById(tenentId);
              await this._Userrepo.Add(user);
                return Ok(user);
            }
            return BadRequest("Not Posted User");
        }
     
        [HttpGet]
       [Route("{tenentId}/user/{username}/{password}")]

        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<dtoValidateUsercs>> GetUserAsPerId(Guid tenentId,string username,string password)
        {
            //EncryptAndDecrypt.ConvertToDecrypt(password)
            if (tenentId.ToString() == null || username == null || password == null)
                return BadRequest("Invalid UserName And Password");

            User validateUser = new User { UserName =username, Password =password };
            User user = await this._Userrepo.FirstOrDefault(x => x.UserName == username && x.Password == password && x.Tenent.Id == tenentId);
            if (user == null)
                return BadRequest("No User Found");
            dtoValidateUsercs token = _tokenManager.CreateToken(user,tenentId);
            return Ok(token);
           
            
        }

        [HttpGet]
        [Route("{tenentId}/user")]
        [EnableCors("CorsPolicy")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersOfATenent(Guid tenentId)
        {
            IEnumerable<User> users=await this._Userrepo.GetListBasedOnCondition(x=>x.Tenent.Id==tenentId);
            if (users.Count()>0)
            {
                return Ok(users);
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{tenentId}/user/{userId}/update")]
        [EnableCors("CorsPolicy")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult> UpdateUser(Guid tenentId, Guid userId,DtoUser usertobeupdated)
        {
            try
            {
                if (ModelState.IsValid)
                { User userToCheckIfExist = new User { Id = userId };
                    var user =await this._Userrepo.FirstOrDefault(x=>x.Tenent.Id==tenentId&& x.Id==userId);
                    user.UserName = usertobeupdated.UserName;
                    user.Password = usertobeupdated.Password;
                    user.Role = usertobeupdated.Role;
                    await this._Userrepo.update(user);
                    return Ok("User is Updated Successfully");
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
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult> DeleteUser(Guid tenentId,Guid userId)
        {
            try
            {
                User user=await this._Userrepo.FirstOrDefault(x=>x.Tenent.Id==tenentId && x.Id==userId);
                if (user.UserName!=null)
                {
                   await this._Userrepo.Remove(user);
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

        [HttpGet]
        [Route("{tenentId}/user/{userId}/addfavourite")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult> addfavourite(Guid tenentId,Guid userId) 
        {
            if (tenentId.ToString() == null || userId.ToString() == null)
                return BadRequest("Invalid user or tenent");
            User user =await this._Userrepo.FirstOrDefault(x => x.Id == userId && x.Tenent.Id == tenentId);
            if(user==null)
                return BadRequest("Invalid user or tenent");
            user.Favourite = "yes";
            await this._Userrepo.update(user);
            return Ok("user Updated successfully");
        }

        [HttpDelete]
        [Route("{tenentId}/user/{userId}/removefavourite")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult> Removefavourite(Guid tenentId, Guid userId)
        {
            if (tenentId.ToString() == null || userId.ToString() == null)
                return BadRequest("Invalid user or tenent");
            User user = await this._Userrepo.FirstOrDefault(x => x.Id == userId && x.Tenent.Id == tenentId);
            if (user == null)
                return BadRequest("Invalid user or tenent");
            user.Favourite = "no";
            await this._Userrepo.update(user);
            return Ok("user Updated successfully");
        }

        [HttpGet]
        [Route("{tenentId}/user/favourite")]
        [SampleJwtAuthorization(Role = new string[] { "superadmin", "Admin" })]
        public async Task<ActionResult<IEnumerable<User>>> GetfavouriteUser(Guid tenentId)
        {
            IEnumerable<User> users = await this._Userrepo.GetListBasedOnCondition(x => 
                                                           x.Tenent.Id == tenentId && x.Favourite.Equals("yes"));
            if (users.Count() > 0)
            {
                return Ok(users);
            }
            return NoContent();
        }


    }
}
