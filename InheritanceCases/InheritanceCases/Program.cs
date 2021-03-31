using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCases
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Man c1 = new Child();
                c1.Play();
                c1.Eat();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Case1();
            Case2();
            Case3();
            Case4();
            Case5();
            Console.Read();


        }

        public static void Case1()
        {
            Console.WriteLine("In Case 1:");
            Man m = new Man();
            m.Play();
            m.Eat();
        }
        public static void Case2()
        {
            Console.WriteLine("In Case2:");
            Boy m = new Boy();
            m.Play();
            m.Eat();
        }

        public static void Case3()
        {
            Console.WriteLine("In Case3:");
            Man m = new Boy();
            m.Play();
            m.Eat();
        }

        static void Case4()
        {
            Console.WriteLine("In case5:");
            Object x;
            x = 10;
            Console.WriteLine(x.GetType());
            x = "hello";
            Console.WriteLine(x.GetType());
            x = new Man();
            Console.WriteLine(x.GetType());
        }
        public static void Case5()
        {
            Child c = new Child();
            Man m = (Man)c;
            m = c;
            
            m.Eat();
            m.Play();
            m.Qar();
        }

    }
}