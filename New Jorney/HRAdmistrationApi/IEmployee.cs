using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdmistrationApi
{
    public interface IEmployee
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }  
        decimal Salary { get; set; }

         
    }
}
