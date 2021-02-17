using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeAnalystProgrammer
{
    class Analyst :Employee
    {
        public const float bonus = 10f;
        public float TA;

        public Analyst(int id, float salary, string name, string dob, float travellingAllowance) : base(id,salary,name,dob)
        {
            this.TA = travellingAllowance;

        }

        public void Bonus()
        {
            this.salary = this.salary + (bonus / 100) * this.salary;
            this.TA = this.TA + (bonus / 100) * this.TA;

        }
        public float ReturnSalary()
        {
            return this.salary;
        }

        public float ReturnTA()
        {
            return this.TA;
        }

    }
}
