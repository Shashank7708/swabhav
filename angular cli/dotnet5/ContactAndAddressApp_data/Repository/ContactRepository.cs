using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ContactAddressCore.Model;
using System.Collections;
using System.Linq;
namespace ContactAndAddressApp_data.Repository

{
   public class ContactRepository:IContactRepository
    {
     private ContactDbContext _db;
        public ContactRepository( ContactDbContext dbContext)
        {
            this._db = dbContext; 
        }

       
        public bool AddTenent(Tenent tenent)
        {
            this._db.Tenents.Add(tenent);
            this._db.SaveChanges();

            return true;
        }


        public Tenent GetTenent(Guid id)
        {
            Tenent tenent = this._db.Tenents.FirstOrDefault(x=>x.Id==id);
            return tenent;
        }

        public IQueryable<Tenent> GetTenents()
        {
            IQueryable<Tenent> tenents = this._db.Tenents.AsQueryable();
            return tenents;
        }
        public Tenent GetTenentbasedonName(string name)
        {
            Tenent tenent = this._db.Tenents.SingleOrDefault(x => x.Name.Equals(name));
            if (tenent == null)
            {
                return null; 
            }
            return tenent;
        }

        public bool UpdateTenent(Tenent tenentToBeUpdated)
        {
            Tenent tenent = this._db.Tenents.SingleOrDefault(x => x.Id == tenentToBeUpdated.Id);
            tenent.Name = tenentToBeUpdated.Name;
            tenent.TenentStrength = tenentToBeUpdated.TenentStrength;
            this._db.SaveChanges();
            return true;
        }
        public bool DeleteTenent(Guid tenentid)
        {
            Tenent tenent = this._db.Tenents.SingleOrDefault(x => x.Id == tenentid);
            List<User> users = this._db.Users.Where(x => x.Tenent.Id == tenent.Id).ToList();
            List<Contact> contacts = this._db.Contacts.Where(x => x.User.Tenent.Id == tenent.Id).ToList();
            List<Address> addresses = this._db.Address.Where(x => x.Contact.User.Tenent.Id == tenent.Id).ToList();
            foreach (var address in addresses)
            {
                this._db.Address.Remove(address);
            }
            foreach (var contact in contacts)
            {
                this._db.Contacts.Remove(contact);
            }
            foreach (var user in users)
            {
                this._db.Users.Remove(user);
            }
            this._db.Tenents.Remove(tenent);
            this._db.SaveChanges();
            return true;
        }
        public bool AddUser(User user)
        {
            this._db.Users.Add(user);
          this._db.SaveChanges();
           return true;
        }
 
       
       

        public IQueryable<User> GetUsers(Guid tenetid)
        {
            IQueryable<User> users = this._db.Users.Include(x=>x.Contacts)
                                                   .Where(x => x.Tenent.Id == tenetid).AsQueryable();
         
            return users;
        }
        public bool UpdateUser(User userToBeUpdated)
        {
            User user = this._db.Users.SingleOrDefault(x => x.Id == userToBeUpdated.Id);
            user.Role = userToBeUpdated.Role;
            user.UserName = userToBeUpdated.UserName;
            user.Password = userToBeUpdated.Password;
            this._db.SaveChanges();
            return true;
        }
        public User GetUser(Guid tenentid,User validateuser)
        {
            User user;
            if (validateuser.UserName != null)
            {
                 user = this._db.Users.SingleOrDefault(usr => usr.UserName.Equals(validateuser.UserName) &&
                                                                  usr.Password.Equals(validateuser.Password) &&
                                                                  usr.Tenent.Id == tenentid);
            }
            else
            {
                 user = this._db.Users.SingleOrDefault(usr => usr.Id==validateuser.Id &&
                                                                 usr.Tenent.Id == tenentid);
            }
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User ValidateUser(string username, string password)
        {
            User user = this._db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public bool DeleteUser(Guid userid)
        {
            User user = this._db.Users.SingleOrDefault(x => x.Id == userid);
            List<Contact> contacts = this._db.Contacts.Where(x => x.User.Id == user.Id).ToList();
            List<Address> addresses = this._db.Address.Where(x => x.Contact.User.Id == user.Id).ToList();
            foreach (var address in addresses)
            {
                this._db.Address.Remove(address);
            }
            foreach (var contact in contacts)
            {
                this._db.Contacts.Remove(contact);
            }
            this._db.Users.Remove(user);
            this._db.SaveChanges();
            return true;

        }

        public void AddContact(Contact contact)
        {
            this._db.Contacts.Add(contact);
            this._db.SaveChanges();
        }
        public Contact GetContactAsPerId(Guid tenetid, Guid userid, Guid contactid)
        {
            var contact = this._db.Contacts.Include(x => x.Address).SingleOrDefault(x => x.Id == contactid && x.User.Id == userid);
            return contact;
        }
        public IQueryable<Contact> GetContacts(Guid tenetid, Guid userid)
        {
            IQueryable<Contact> contacts = this._db.Contacts.Include(contact => contact.Address).Where(x => x.User.Id == userid && x.User.Tenent.Id == tenetid);
            return contacts;
        }

        public bool UpdateContact(Contact toUpdatecontact)
        {
            Contact contact = this._db.Contacts.SingleOrDefault(x => x.Id == toUpdatecontact.Id);
            contact.Name = toUpdatecontact.Name;
            contact.Mobileno = toUpdatecontact.Mobileno;
            this._db.SaveChanges();
            return true;
        }
        public bool DeleteContact(Guid id)
        {
            Contact contact = this._db.Contacts.SingleOrDefault(x => x.Id == id);
            List<Address> addresses = this._db.Address.Where(x => x.Contact.Id == contact.Id).ToList();
            foreach (var address in addresses)
            {
                this._db.Address.Remove(address);
            }
            this._db.Contacts.Remove(contact);
            this._db.SaveChanges();
            return true;

        }

        public void AddAddress(Address address)
        {
            this._db.Address.Add(address);
            this._db.SaveChanges();
        }

        public IQueryable<Address> GetAddresss(Guid tenetid, Guid userid, Guid contactid)
        {
            IQueryable<Address> address = this._db.Address.Where(x => x.Contact.Id == contactid && x.Contact.User.Id==userid && x.Contact.User.Tenent.Id==tenetid).AsQueryable();
            return address;
        }

    

    
        public Address GetAddres(Guid tenetid,Guid userid,Guid contactid,Guid addressId)
        {
            var address = this._db.Address.SingleOrDefault(x => x.Id == addressId && x.Contact.Id==contactid && x.Contact.User.Id==userid && x.Contact.User.Tenent.Id==tenetid);
            return address;
        }


      

       

        public bool UpdateAddress(Address addresstoupdate)
        {
            Address address = this._db.Address.SingleOrDefault(x => x.Id == addresstoupdate.Id);
            address.Country = addresstoupdate.Country;
            address.State = addresstoupdate.State;
            address.City = addresstoupdate.City;
            this._db.SaveChanges();
            return true;
        }

        public bool DeleteAddress(Guid id)
        {
            Address address = this._db.Address.SingleOrDefault(x => x.Id == id);
        
            this._db.Address.Remove(address);
            this._db.SaveChanges();
            return true;
        }

       

        

     

       

      
    }
}
