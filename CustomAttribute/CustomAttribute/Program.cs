using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomAttribute
{
    class Program
    {
        static void Main(string[] args)
        {

            Type t = typeof(foo);
            PrintMethod(t);
            Console.Read();
        }
        static void PrintMethod(Type t)
        {
            int count = 0;
            object fooinst = Activator.CreateInstance(t);
            MethodInfo[] listofmethod = t.GetMethods();
            Console.WriteLine("Custom Attr:");
            foreach(var method in listofmethod)
            {
                object[] attributearray = method.GetCustomAttributes(true);
                foreach(Attribute item in attributearray)
                {
                    if(item is MyCustomAttribute)
                    {
                        MyCustomAttribute customAttribute = (MyCustomAttribute)item;
                        Console.Write(method.Name+": ");
                        bool value = (bool)method.Invoke(fooinst, null);
                        Console.WriteLine(value);
                     


                        count++;
                    }
                }
            }
            
        }

    }
}
