using ContactAndAddressCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressAPP_data.Repository
{
  public  class ContactRepository
    {
        ContactDbContext db;

           protected ContactRepository()
        {
            db = new ContactDbContext();
        }

        public List<Contact> Contacts()
        {
          return  db.contacts.ToList();
        }

    }
}
