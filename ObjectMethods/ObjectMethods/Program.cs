using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            string s1 = "Testing Object";
            string s2 = "Testing Object";

            Type t1 = c1.GetType();
            Type t2 = s1.GetType();
            //Object class Method
            Console.WriteLine(t1.BaseType);
            Console.WriteLine(t1.Name);
            Console.WriteLine(t1.FullName);
            Console.WriteLine(t1.Namespace);

            Class1 class1obj1 = new Class1();
            Class1 class1obj2 = new Class1();
            Class2 class2obj1 = new Class2();
            Console.WriteLine("Comparing of 2 objects");
            Console.WriteLine(class1obj1.Equals(class1obj2));
            Console.WriteLine(Object.Equals(class1obj2, class2obj1));
            Console.WriteLine(object.Equals(class1obj1, class1obj1));

            Console.WriteLine("Comparing 2 object using reference");
            Console.WriteLine(Object.ReferenceEquals(class1obj1, class1obj2));
            Console.WriteLine(object.ReferenceEquals(class1obj1, class2obj1));
            Console.WriteLine(object.ReferenceEquals(class1obj1, class1obj1));
            Console.WriteLine(object.ReferenceEquals(s1, s1));

            object o1 = null;
            object o2 = new object();
            Console.WriteLine("Comparing 2 object i is null and other is instance of class");
            //Technically, these should read object.ReferenceEquals for clarity, but this is redundant.
            ReferenceEquals(o1, o1); //true
            ReferenceEquals(o1, o2); //false
            ReferenceEquals(o2, o1); //false
            ReferenceEquals(o2, o2); //true
            /*  try
              {

                  o2.Equals(o1); //false
                  o2.Equals(o2); //true
                  o1.Equals(o1); //NullReferenceException
                  o1.Equals(o2); //NullReferenceException
              }
              catch(Exception e)
              {
                  Console.WriteLine(e.Message);
              }
            */
            Console.WriteLine("Float to string Using toString method");
            float floattostringeg = 45.4f;
            Console.WriteLine(floattostringeg.ToString());

            Console.ReadLine();




        }
    }
}
