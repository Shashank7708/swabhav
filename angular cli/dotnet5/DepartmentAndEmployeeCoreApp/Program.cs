using System;
using DepartmentAndEmployeeCoreApp.DbContext1;
using DepartmentAndEmployeeCoreApp.Model;
using System.Linq;

namespace DepartmentAndEmployeeCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {   /*
            Department accounting = new Department { Id = Guid.NewGuid(), name = "hr", Location = "Vasai" };
            Employee sachin = new Employee { Id = Guid.NewGuid(), name = "Sachin", address = "Palghar", age = 39 };
            sachin.depatartment = accounting;
           accounting.Employees.Add(sachin);
            ContactDbContext db = new ContactDbContext();
            db.Employees.Add(sachin);
            db.SaveChanges();
           
            Department marketing = new Department { Id = Guid.NewGuid(), name = "marketing", Location = "Mumbai" };
            Employee vishal = new Employee { Id = Guid.NewGuid(), name = "vishal", address = "Kurla", age = 29 };
            Employee shehan = new Employee { Id = Guid.NewGuid(), name = "shehan", address = "Virar", age = 22 };
            Employee romy = new Employee { Id = Guid.NewGuid(), name = "romy", address = "Vasai", age = 25 };
            vishal.depatartment = marketing;
           shehan.depatartment = marketing;
            romy.depatartment = marketing;
            marketing.Employees.Add(vishal);
            marketing.Employees.Add(shehan);
            marketing.Employees.Add(romy);
            ContactDbContext db = new ContactDbContext();
            db.Departents.Add(marketing);
            db.SaveChanges();
            */

            ContactDbContext db = new ContactDbContext();
            Query(db);

            Console.WriteLine("Done");
            Console.ReadLine();
        }


        private static void Query(ContactDbContext contactDbContext)
        {
            ContactDbContext db = contactDbContext;
            Console.ForegroundColor = ConsoleColor.Red;
            var departments = from department in db.Departents
                              select department;
            Console.WriteLine("Departments:");
            foreach(var department in departments)
            {
                Console.WriteLine(department);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employees");
            var employees = from employee in db.Employees
                              select employee;
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }


        }

    }
}
