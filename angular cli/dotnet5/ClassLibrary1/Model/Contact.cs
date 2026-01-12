using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int mobileno { get; set; }

        public virtual Address address { get; set; }

    }
}
