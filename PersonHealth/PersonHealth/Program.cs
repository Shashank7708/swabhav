using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHealth
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(23, "Romy", "Male", 50f, 160f);    
            PersonInfo(person1);                 
            ShowBmr(person1);
            person1.eat();
            ShowBmr(person1);
            Console.ReadLine();

        }


        static void PersonInfo(Person p)
        {
            Console.Write("Name: " + p.getName() + "\nAge: " + p.getAge() + "\nSex: " + p.getGender());
            Console.Write("\nWeight: " + p.getWeight() + "\nHeight: " + p.getHeight());
        }

        static void ShowBmr(Person p)
        {
            Console.Write("\nBMR: " + p.BMR());
        }

        static void ShowWeight(Person p)
        {
            Console.Write("Weight: " + p.getWeight());
        }
    }
}
