using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    class GuessGame
    {
        int randomnum = 30;
        private int userguess;

        public int UserGuess
        {
            set { this.userguess = value; }
        }
        public bool CheckUserGuess        //To check user Guess
        {
            get
            {
                if (userguess == randomnum)                           //The User has guess Correctly,Return True
                    return false;
                else if (userguess > randomnum)
                    Console.WriteLine("Hint: Your guess is high\n");     //User Guess is Greater than Random no
                else
                    Console.WriteLine("Hint: Your guess is low\n");       //User Guess is smaller than Random no
                return true;
            }
        }
    }
}
