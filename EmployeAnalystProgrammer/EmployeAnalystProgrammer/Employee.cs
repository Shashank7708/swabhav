using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeAnalystProgrammer
{
    class Employee
    {
        public float salary;
        public int id;
        public string name;
        

        public DateTime Dob;
        public Employee(int id, float salary,string name,string d)
        {
            this.id = id;
            this.salary = salary;
            this.name = name;
            Dob = Convert.ToDateTime(d);
        }
        
        public void AnalystBonus(float sal)
        {
            salary = sal;
            
        }

    }
}
