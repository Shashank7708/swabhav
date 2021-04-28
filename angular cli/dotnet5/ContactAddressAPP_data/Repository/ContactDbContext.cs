using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAndAddressCore.Models;

namespace ContactAddressAPP_data.Repository
{
   public class ContactDbContext:DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
         : base(options)
        { }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Address> address { get; set; }
    }
}
