using HRAdmistrationApi;
using System.Linq;
namespace ConsoleApp1
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSaalry = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);
            //foreach(var emp in employees)
            //{
            //    totalSaalry = totalSaalry + emp.Salary;
            //}
            //Console.WriteLine($"Total Annual Salary (including Bonus)= {totalSaalry}");

            //Using Linq
            Console.WriteLine($"Total Annual Salary (including Bonus)= {employees.Sum(x => x.Salary)}");

            Console.Read();
        }
        
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee employee1= EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,1, "Bob", "Fisher",4M);
            employees.Add(employee1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Ronty", "Muscle", 600M); 
            employees.Add(teacher2);

            IEmployee headOfDepartment1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "brandon", "Clark", 50M);
            employees.Add(headOfDepartment1);

            IEmployee headOfDepartment2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 4, "Tyson", "Varghese", 70M);
            employees.Add(headOfDepartment2);
        }
    }

    public class Teacher : Employee
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.2m; }
    }
    public class HeadOfDepartment : Employee
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.6m; }

    }

    public abstract class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType,int id, string firstName,string lastName,decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Teacher: 
                    employee=new Teacher { Id = id, FirstName =firstName,LastName=lastName,Salary=salary }; 
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = new HeadOfDepartment { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                default: 
                    break;

            }
            return employee;
        }
    }

}
