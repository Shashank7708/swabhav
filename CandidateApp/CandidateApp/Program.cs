using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CandidateApp[] c = new CandidateApp[2];
            c[0] = new CandidateApp(101,"Shashank",'A',45);

            c[1] = new CandidateApp(102, "Rohan", 'B',32);

            Console.WriteLine("Detail of 1st candidate:");
            Console.WriteLine("id= " + c[0].id + "\nname= " + c[0].name + "\ncreditpoint=" + c[0].creditpoint+"\nAge= "+c[0].age+"\n");
            Console.WriteLine("Detail of 2st candidate:");
            Console.WriteLine("id= " + c[1].id + "\nname= " + c[1].name + "\ncreditpoint=" + c[1].creditpoint+ "\nAge= " + c[1].age+"\n\n\n");
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
                Console.WriteLine("\n"+c[1].id + " is elder than "+ c[1].id);
            }
            else
            {
                Console.WriteLine("\n"+c[0].id + " is elder than " + c[1].id);
            }
            Console.ReadLine();

        }
    }
}
