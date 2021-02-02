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

        public bool CheckUserGuess(int userguess)         //To check user Guess
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
