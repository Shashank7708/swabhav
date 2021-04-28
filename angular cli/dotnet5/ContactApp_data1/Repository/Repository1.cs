using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCore.Model;

namespace ContactApp_data1.Repository
{
   public class Repository1
    {
        public IEnumerable<Contact> getContact()
        {
            Contact c = new Contact { Id = Guid.NewGuid(), Name = "Romy", mobileno = 3362828 };
            List<Contact> contacts = new List<Contact>();
            contacts.Add(c);
            return contacts;
        }


    }
}
