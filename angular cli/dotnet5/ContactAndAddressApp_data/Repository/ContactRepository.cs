using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ContactAddressCore.Model;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressApp_data.Repository

{
   public class ContactRepository:IContactRepository
    {
     private ContactDbContext _db;
        public ContactRepository( ContactDbContext dbContext)
        {
            this._db = dbContext; 
        }

       
        public async Task<bool> AddTenent(Tenent tenent)
        {
            this._db.Tenents.Add(tenent);
            await this._db.SaveChangesAsync();

            return true;
        }


        public async Task<Tenent> GetTenent(Guid id)
        {
            return await this._db.Tenents.FirstOrDefaultAsync(x => x.Id == id);           
        }

        public async Task<List<Tenent>> GetTenents()
        {  
               return await this._db.Tenents.ToListAsync(); 
            
        }
        public async Task<Tenent> GetTenentbasedonName(string name)
        {
            Tenent tenent =await this._db.Tenents.SingleOrDefaultAsync(x => x.Name.Equals(name));
            if (tenent == null)
            {
                return null; 
            }
            return tenent;
        }

        public async Task<bool> UpdateTenent(Tenent tenentToBeUpdated)
        {
            Tenent tenent =await this._db.Tenents.SingleOrDefaultAsync(x => x.Id == tenentToBeUpdated.Id);
            tenent.Name = tenentToBeUpdated.Name;
            tenent.TenentStrength = tenentToBeUpdated.TenentStrength;
          await this._db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteTenent(Guid tenentid)
        {
            Tenent tenent =await this._db.Tenents.SingleOrDefaultAsync(x => x.Id == tenentid);
            List<User> users =await this._db.Users.Where(x => x.Tenent.Id == tenent.Id).ToListAsync();
            List<Contact> contacts =await this._db.Contacts.Where(x => x.User.Tenent.Id == tenent.Id).ToListAsync();
            List<Address> addresses =await this._db.Address.Where(x => x.Contact.User.Tenent.Id == tenent.Id).ToListAsync();
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
           await this._db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddUser(User user)
        {
            this._db.Users.Add(user);
         await this._db.SaveChangesAsync();
           return true;
        }
 
    

        public async Task<List<User>> GetUsers(Guid tenetid)
        {
           return await this._db.Users.Where(x => x.Tenent.Id == tenetid).ToListAsync();            
        }
        public async Task<bool> UpdateUser(User userToBeUpdated)
        {
            User user =await this._db.Users.SingleOrDefaultAsync(x => x.Id == userToBeUpdated.Id);
            user.Role = userToBeUpdated.Role;
            user.UserName = userToBeUpdated.UserName;
            user.Password = userToBeUpdated.Password;
           await this._db.SaveChangesAsync();
            return true;
        }
        public async Task<User> GetUser(Guid tenentid,User validateuser)
        {
            User user;
            if (validateuser.UserName != null)
            {
                 user =await this._db.Users.SingleOrDefaultAsync(usr => usr.UserName.Equals(validateuser.UserName) &&
                                                                  usr.Password.Equals(validateuser.Password) &&
                                                                  usr.Tenent.Id == tenentid);
            }
            else
            {
                 user =await this._db.Users.SingleOrDefaultAsync(usr => usr.Id==validateuser.Id &&
                                                                 usr.Tenent.Id == tenentid);
            }
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            User user =await this._db.Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<bool> DeleteUser(Guid userid)
        {
            User user = this._db.Users.SingleOrDefault(x => x.Id == userid);
            List<Contact> contacts =await this._db.Contacts.Where(x => x.User.Id == user.Id).ToListAsync();
            List<Address> addresses =await this._db.Address.Where(x => x.Contact.User.Id == user.Id).ToListAsync();
            foreach (var address in addresses)
            {
                this._db.Address.Remove(address);
            }
            foreach (var contact in contacts)
            {
                this._db.Contacts.Remove(contact);
            }
            this._db.Users.Remove(user);
          await this._db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AddContact(Contact contact)
        {
            this._db.Contacts.Add(contact);
            await this._db.SaveChangesAsync();
            return true;
        }
        public async Task<Contact> GetContactAsPerId(Guid tenetid, Guid userid, Guid contactid)
        {
            var contact =await this._db.Contacts.Include(x => x.Address).SingleOrDefaultAsync(x => x.Id == contactid && x.User.Id == userid);
            return contact;
        }
        public async Task<List<Contact>> GetContacts(Guid tenetid, Guid userid)
        {
            List<Contact> contacts =await this._db.Contacts.Include(contact => contact.Address).Where(x => x.User.Id == userid && x.User.Tenent.Id == tenetid).ToListAsync();
            return contacts;
        }

        public async Task<bool> UpdateContact(Contact toUpdatecontact)
        {
            Contact contact =await this._db.Contacts.SingleOrDefaultAsync(x => x.Id == toUpdatecontact.Id);
            contact.Name = toUpdatecontact.Name;
            contact.Mobileno = toUpdatecontact.Mobileno;
           await this._db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteContact(Guid id)
        {
            Contact contact =await this._db.Contacts.SingleOrDefaultAsync(x => x.Id == id);
            List<Address> addresses =await this._db.Address.Where(x => x.Contact.Id == contact.Id).ToListAsync();
            foreach (var address in addresses)
            {
                this._db.Address.Remove(address);
            }
            this._db.Contacts.Remove(contact);
            await this._db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AddAddress(Address address)
        {
            this._db.Address.Add(address);
            await this._db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Address>> GetAddresss(Guid tenetid, Guid userid, Guid contactid)
        {
            List<Address> address =await this._db.Address.Where(x => x.Contact.Id == contactid && x.Contact.User.Id==userid && x.Contact.User.Tenent.Id==tenetid).ToListAsync();
            return address;
        }

    

    
        public async Task<Address> GetAddres(Guid tenetid,Guid userid,Guid contactid,Guid addressId)
        {
            var address =await this._db.Address.SingleOrDefaultAsync(x => x.Id == addressId && x.Contact.Id==contactid && x.Contact.User.Id==userid && x.Contact.User.Tenent.Id==tenetid);
            return address;
        }


      

       

        public async Task<bool> UpdateAddress(Address addresstoupdate)
        {
            Address address =await this._db.Address.SingleOrDefaultAsync(x => x.Id == addresstoupdate.Id);
            address.Country = addresstoupdate.Country;
            address.State = addresstoupdate.State;
            address.City = addresstoupdate.City;
            await this._db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAddress(Guid id)
        {
            Address address =await this._db.Address.SingleOrDefaultAsync(x => x.Id == id);
        
            this._db.Address.Remove(address);
           await this._db.SaveChangesAsync();
            return true;
        }

       

        

     

       

      
    }
}
