using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionClass rc = new ReflectionClass();
            Type Classname = rc.GetType();
            Console.WriteLine(Classname);
            MethodInfo[] methodname = Classname.GetMethods();
            foreach(MethodInfo  i in methodname)
            {
                Console.WriteLine("--MetodName:" + i.Name);
                ParameterInfo[] param = i.GetParameters();
                foreach (ParameterInfo parmeter in param)
                    Console.WriteLine("-------Parameter:" + parmeter.Name);
            }
            Console.WriteLine("\nOnly Property");
            PropertyInfo[] onlyproperty = Classname.GetProperties();
            foreach(PropertyInfo i in onlyproperty)
            {
                Console.WriteLine("----" + i.Name);
            }
            Console.WriteLine("\ninstance variable");
            FieldInfo[] io = Classname.GetFields();
            foreach(FieldInfo i in io)
            {
                Console.WriteLine("--InstanceVar:"+i.Name);
            }
            
        
            Console.ReadLine();
        }
    }
}
