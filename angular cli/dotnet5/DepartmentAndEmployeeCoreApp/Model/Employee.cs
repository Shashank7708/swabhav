using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentAndEmployeeCoreApp.Model
{
    class Employee
    {
        public Guid Id { get; set; }
        public string name { get; set; }
       
        public string address { get; set; }
        public int age { get; set; }
        public virtual Department depatartment { get; set; }
        public override string ToString()
        {
            return "Id: " + Id + ", Name:" + name + ", Age:" + age + ", Address:" + address + ", Department-Name:"+depatartment.name+"\n";
        }

    }
}
