using EFCoreApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp.Repository
{
    class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"server=.\SQLExpress; Database=ContactAndAddress; User Id=sa; Password=root;");

        }
        public DbSet<Student> Students { get; set; }
    }
}
