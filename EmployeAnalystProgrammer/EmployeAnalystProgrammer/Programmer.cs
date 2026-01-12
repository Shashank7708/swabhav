using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeAnalystProgrammer
{
    class Programmer : Employee
    {
        public const float bonus = 20f;
       

        public Programmer(int id, float salary, string name,string dob) : base(id, salary, name, dob)
        {
            

        }

        public void Bonus()
        {
            this.salary = this.salary + (bonus / 100) * this.salary;
            

        }
    }
}
