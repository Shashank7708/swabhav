using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank b1 = new Bank(101, "Rohan", 1500.0f);
            Bank b2 = new Bank(102, "Suhas", 1000.54f);
            Bank b3 = new Bank(103, "sumit", 750f);
            Transaction(b1);
            

            /*
            Console.WriteLine("Original:");
            PrintAccountInfo(b1);
            b1.withdraw(500f);
            Console.WriteLine("\n\n");

            ShowBalance()
            PrintAccountInfo(b3);
            b3.withdraw(500);
            Console.WriteLine("After transctions:");
            PrintAccountInfo(b3);
            



            Console.WriteLine("\n\n");
            Console.WriteLine("Original:");
            PrintAccountInfo(b2);
            b2.deposit(500f);
            Console.WriteLine("After transcation");
            PrintAccountInfo(b2);
            */
            Console.ReadLine();


        }

        static void PrintAccountInfo(Bank b)
        {
            Console.WriteLine("Accountno= "+b.getAccountno() + "\tBalance= " + b.getBalance());
        }
        static void ShowBalance(Bank b) {
            Console.WriteLine("Remaining Balannce:" + b.getBalance());
        }

        static void  Transaction(Bank b1)
        {
            Console.WriteLine("\n\n");
           
            PrintAccountInfo(b1);
            while (b1.getBalance() > 500)
            {
                Console.WriteLine("Enter your choice:\n1 for withdraw\t 2 for deposit");


                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter the amt to withdraw");

                    float amt = float.Parse(Console.ReadLine());
                    if (b1.getBalance() > 500)
                    {

                        b1.withdraw(amt);
                        Console.WriteLine("Balance:" + b1.getBalance());
                    }
                    else
                    {

                        Console.WriteLine("Alert:Dont have sufficient balance");
                        Console.WriteLine("Balance:" + b1.getBalance());
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the amt to deposit:");
                    float dep = float.Parse(Console.ReadLine());
                    b1.deposit(dep);
                    Console.WriteLine("Balance:" + b1.getBalance());

                }
           
            }
        }
    }
}
