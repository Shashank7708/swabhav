using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionEG
{
   public class Account
    {
        public int accountno { get; set; }
        public string namee { get; set; }

        public double bal { get; set; }
        public bool withdraw(double amt)
        {
            if (bal < 500) 
                return false;
            bal = bal - amt;
            return true;
            }

        }
    }

