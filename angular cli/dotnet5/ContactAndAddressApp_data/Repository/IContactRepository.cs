using ContactAddressCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAndAddressApp_data.Repository
{
   public interface IContactRepository
    {
       

       Task<bool> AddTenent(Tenent tenent);
       Task<bool> AddUser(User user);
       Task<List<Tenent>> GetTenents();
       Task<Tenent> GetTenent(Guid id);
      
        Task<bool> AddAddress(Address address);
        Task<bool> AddContact(Contact contact);
        Task<User> GetUser(Guid tenentid, User validateuser);
        Task<List<Address>> GetAddresss(Guid tenetid, Guid userid, Guid contactid);
     Task<List<User>> GetUsers(Guid tenetid);
        Task<Contact> GetContactAsPerId(Guid tenetid, Guid userid, Guid contactid);
        Task<List<Contact>> GetContacts(Guid tenetid, Guid userid);
        Task<Address> GetAddres(Guid tenetid, Guid userid, Guid contactid, Guid addressId);
        Task<bool>  UpdateContact(Contact toUpdatecontact);
        Task<bool> DeleteContact(Guid id);
        Task<bool> UpdateAddress(Address addresstoupdate);
       Task<bool> DeleteAddress(Guid id);
       Task<bool> DeleteUser(Guid userId);
       Task<bool> DeleteTenent(Guid tenentId);
       Task<bool> UpdateUser(User userToBeUpdated);
       Task<bool> UpdateTenent(Tenent tenentToBeUpdated);
       Task<User> ValidateUser(string username, string password);
       Task<Tenent> GetTenentbasedonName(string name);
    }

}
