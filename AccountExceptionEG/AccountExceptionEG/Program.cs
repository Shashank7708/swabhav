using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionEG
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account() {accountno= 101, namee="Romy",bal= 3000 };

            PrintInfo(a1);
            int i = 2;
            while (i-- > 0)
            {
                Console.WriteLine("Transaction:");

                try
                {
                    bool withdraw = true; ;
                    double amt = double.Parse(Console.ReadLine());
                    if (a1.bal > 500)
                    {
                        withdraw = a1.withdraw(amt);
                        throw new InsufficientBalException();
                    }
                    if (withdraw == false)
                    {
                        Console.WriteLine("Remaining balance:" + a1.bal);
                        throw new InsufficientBalException();
                    }
                    Console.WriteLine("Remaining balance:" + a1.bal);

                    
                }
                catch (InsufficientBalException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();

        }
        static void PrintInfo(Account a)
        {
            Console.WriteLine("AccountName: " + a.namee + "\nAccount no: {0}\nBalance: {1}", a.accountno, a.bal);
        }
    }
}
