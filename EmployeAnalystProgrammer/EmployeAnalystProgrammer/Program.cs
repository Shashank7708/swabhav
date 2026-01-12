using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeAnalystProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {   //Analyst Object
            Analyst analyst1 = new Analyst(101,20000.0f,"Romy","1998-11-11",20000f);
            PrintAnalystPRofile(analyst1);
            GiveBonusToAnalyst(analyst1);
            Seperator();


            //PRogrammer Object
            Programmer programmer1 = new Programmer(201, 29000.0f, "Rohan", "1995-10-27");
            PrintProgrammerProfile(programmer1);
            GiveBonusToPrg(programmer1);
            Seperator();
            Console.WriteLine(programmer1 is Employee);

            //Manager Profile
            Manager manager1 = new Manager(301, 79000f, "Sumit", "1991-01-21", 10000f, 5000f, 7000f);
            PrintManagerProfile(manager1);
            GiveBonusToMngr(manager1);


            Console.ReadLine();
        }

        static void Seperator()
        {
            Console.WriteLine("##################################################\n");
        }
        static void PrintAnalystPRofile(Analyst s1)
        {
            Console.WriteLine("Analyst Profile");
            Console.WriteLine("Id: " + s1.id + "\nSalary: " + s1.salary + "\nName: " + s1.name + "\nDOB: " + s1.Dob + "\nTA: " + s1.TA);
        }
        static void GiveBonusToAnalyst(Analyst s1)
        {
            s1.Bonus();
            Console.WriteLine("\nAFTER INCREMENT:");
            Console.WriteLine("Salary:" + s1.salary + "\nTA: " + s1.ReturnSalary());
        }

        static void PrintProgrammerProfile(Programmer p)
        {
            Console.WriteLine("Programmer Profile");
            Console.WriteLine("Id: " + p.id + "\nSalary: " + p.salary + "\nName: " + p.name + "\nDOB: " + p.Dob);
            
        }

        static void GiveBonusToPrg(Programmer p)
        {
            p.Bonus();
            Console.WriteLine("\nAFTER INCREMENT:");
            Console.WriteLine("Salary:" + p.salary);
        }

        static void PrintManagerProfile(Manager m)
        {
            Console.WriteLine("Manager Profile");
            Console.WriteLine("Id: " + m.id + "\nSalary: " + m.salary + "\nName: " + m.name + "\nDOB: " + m.Dob);
            Console.WriteLine("TA: {0}\nDA: {1}\nHRA: {2}", m.TA, m.DA, m.HRA);
        }
        static void GiveBonusToMngr(Manager m)
        {
            m.Bonus();
            Console.WriteLine("\nAFTER INCREMENT:");
            Console.WriteLine("Salary: {0}\nTA: {1}\nDA: {2}\nHRA: {3}",m.salary,m.TA,m.DA,m.HRA);
        }
    }
}
