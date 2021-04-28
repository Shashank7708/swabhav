using DepartmentAndEmployeeCoreApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentAndEmployeeCoreApp.DbContext1
{
    class ContactDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"server=.\SQLExpress; Database=DeptAndEmpCore; User Id=sa; Password=root;");

        }
        public DbSet<Department> Departents { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
