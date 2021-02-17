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
            Person person1 = new Person();
            person1.getAge = 23;
            person1.getName = "Romy";
            person1.getGender = "Male";
            person1.getWeight = 50f;
            person1.getHeight = 160f;
            PersonInfo(person1);                 
            ShowBmr(person1);
            person1.eat();
            Console.Write("\nAfter eating:");
            ShowBmr(person1);
            
            
           

            Console.ReadLine();

        }


        static void PersonInfo(Person p)
        {
            Console.Write("Name: " + p.getName + "\nAge: " + p.getAge + "\nSex: " + p.getGender);
            Console.Write("\nWeight: " + p.getWeight + "\nHeight: " + p.getHeight+"\n");
        }

        static void ShowBmr(Person p)
        {
            Console.Write("BMR: " + p.BMR);
        }

        static void ShowWeight(Person p)
        {
            Console.Write("Weight: " + p.getWeight);
        }
    }
}
