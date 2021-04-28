using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DepartmentAndEmployeeCoreApp.Model
{   [Table("Department")]
    class Department
    {   

        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
        public string Location { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public override string ToString()
        {
            return "Id: " + Id + ", Name:" + name + ", Locations:" + Location + "\n";
        }
    }
}
