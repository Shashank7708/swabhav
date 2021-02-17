using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp
{
    class CandidateApp
    {
        private int ID;
        private string Name;
        private char Creditpoint;
        private int Age;

        public int id
        {
            set{
                this.ID = value;
            }
            get
            {
                return this.ID;
            }
        }

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public int age
        {
            set { this.Age = value; }
            get { return this.Age; }
        }

        public char creditpoint
        {
            set { this.Creditpoint = value; }
            get { return this.Creditpoint; }
        }


        
    }
}
