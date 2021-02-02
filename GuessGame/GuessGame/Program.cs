using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
                                                                    //Initializing Random number
            int noOfTurns = 0;                                      //TO calculate no of Attemptes                         
            bool temp = true;
            while (temp)
            {
                Console.Write("Enter your no:");
                try
                {
                    int userguess = Convert.ToInt32(Console.ReadLine());       //Take User Guess
                    temp = new GuessGame().CheckUserGuess(userguess);          //Check User Input
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                noOfTurns++;

            }
             Console.WriteLine("Congrulation Your Guess is Right");
            Console.WriteLine("No. Of Attempts= " +(noOfTurns));
            Console.ReadLine();
        }

        
    }

}
