using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeAnalystProgrammer
{
    class Manager :Employee
    {
        public const float bonus = 15f;
        public float TA;
        public float DA;
        public float HRA;
        public Manager(int id, float salary, string name, string dob, float TA,float DA,float HRA) : base(id, salary, name, dob)
        {
            this.TA = TA;
            this.DA = DA;
            this.HRA = HRA;


        }

        public void Bonus()
        {
            this.salary = this.salary + (bonus / 100) * this.salary;
            this.TA = this.TA + (bonus / 100) * this.TA;
            this.DA = this.DA + (bonus / 100) * this.DA;
            this.HRA = this.HRA + (bonus / 100) * this.HRA;

        }
    }
}
