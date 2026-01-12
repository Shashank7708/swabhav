using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCore.Model;

namespace ContactApp_data1.Repository
{
    class ContactDbContext1:DbContext
    {
        public ContactDbContext1() : base("ContactDbContext1")
        {
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Address> address { get; set; }

    }
}
