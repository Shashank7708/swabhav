using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ContactAddressCore.Model;

namespace ContactAndAddressApp_data.Repository
{
   public class ContactDbContext:DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Tenent> Tenents { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
