using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigGame
{
    class Program
    {

        
static void Main(string[] args)
        {

            bool isPlaying = true;
            Console.WriteLine("Pig Game");
            string ip;
            int userttl = 0;
            int usertotal = 0;
            int rnd;
            int counter = 1;
            bool roll = true;
            while (isPlaying)
            {
                if (usertotal >= 20)
                {
                    Console.WriteLine($"Total score {usertotal} has been reached\nTurns taken to reach : {counter}");

                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine($"TURN {counter++}");
                    roll = true;
                    while (roll)
                    {

                        if (userttl >= 20 || usertotal >= 20)
                        {
                            roll = false;
                        }
                        else
                        {
                            Console.Write("Roll or Hold  (r/h) : ");

                            ip = Console.ReadLine();

                            if (ip.ToLower().Equals("r"))
                            {
                                rnd = getrndno();
                                if (rnd != 1)
                                {
                                    Console.WriteLine($"Die : {rnd}");
                                    userttl += rnd;
                                }
                                else
                                {
                                    Console.WriteLine("Total ");
                                    usertotal = 0;
                                    userttl = 0;
                                }
                            }
                            else if (ip.ToLower().Equals("h"))
                            {
                                Console.WriteLine($"Score For Turn : {userttl}");

                                usertotal += userttl;
                                userttl = 0;
                                Console.WriteLine($"Total score : {usertotal}");
                                roll = false;

                            }

                        }

                    }
                    if (usertotal >= 20)
                    {
                        Console.WriteLine($"Total score {usertotal} has been reached\nTurns taken to reach : {counter}");
                        isPlaying = false;
                    }

                }



            }
            Console.ReadLine();
        }



        public static int getrndno()
        {

            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}