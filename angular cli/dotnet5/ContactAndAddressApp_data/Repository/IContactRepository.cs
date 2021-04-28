using ContactAddressCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactAndAddressApp_data.Repository
{
   public interface IContactRepository
    {
       

        bool AddTenent(Tenent tenent);
        bool AddUser(User user);
        IQueryable<Tenent> GetTenents();
        Tenent GetTenent(Guid id);
      
        void AddAddress(Address address);
        void AddContact(Contact contact);
        User GetUser(Guid tenentid, User validateuser);
        IQueryable<Address> GetAddresss(Guid tenetid, Guid userid, Guid contactid);
      IQueryable<User> GetUsers(Guid tenetid);
        Contact GetContactAsPerId(Guid tenetid, Guid userid, Guid contactid);
        IQueryable<Contact> GetContacts(Guid tenetid, Guid userid);
        Address GetAddres(Guid tenetid, Guid userid, Guid contactid, Guid addressId);
        bool  UpdateContact(Contact toUpdatecontact);
        bool DeleteContact(Guid id);
        bool UpdateAddress(Address addresstoupdate);
        bool DeleteAddress(Guid id);
        bool DeleteUser(Guid userId);
        bool DeleteTenent(Guid tenentId);
        bool UpdateUser(User userToBeUpdated);
        bool UpdateTenent(Tenent tenentToBeUpdated);
        User ValidateUser(string username, string password);
        Tenent GetTenentbasedonName(string name);
    }

}
