using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreApp.Model
{   [Table("Student")]
    class Student
    {   [Key]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string Class { get; set; }
        public char Div { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nFName: " + Fname + "\nLname: " + LName + "\nClass: " + Class + "\nDiv: " + Div+"\n\n";
        }

    }
}
