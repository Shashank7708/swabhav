using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp
{
    class Program
    {
        static int count = 1;
        static void Main(string[] args)
        {
            CandidateApp[] c = new CandidateApp[2];
            for(int i = 0; i < 2; i++)
            {
                c[i] = new CandidateApp();
            }
            c[0].id = 101;
            c[0].name = "Romy";
            c[0].creditpoint = 'A';
            c[0].age = 23;

            c[1].id = 102;
            c[1].name = "Rohan";
            c[1].creditpoint = 'B';
            c[1].age = 45;
            PrintInfo(c[0]);
            PrintInfo(c[1]);
            Console.WriteLine("***************************************");
            if (c[0].creditpoint < c[1].creditpoint)
            {
                Console.WriteLine(c[0].id + " has more credit");
            }
            else
            {
                Console.WriteLine(c[1].id + " has more credit");
            }

            if (c[0].age < c[1].age)
            {
                Console.WriteLine("\n" + c[1].id + " is elder than " + c[1].id);
            }
            else
            {
                Console.WriteLine("\n" + c[0].id + " is elder than " + c[1].id);
            }
            Console.ReadLine();

        }

        static void PrintInfo(CandidateApp c)
        {  
            Console.WriteLine("***************************************");
            Console.WriteLine("Detail of {0}st candidate:",count++);
            Console.WriteLine("id= " + c.id + "\nname= " + c.name + "\ncreditpoint=" + c.creditpoint + "\nAge= " + c.age + "\n");
        }
    }
}
