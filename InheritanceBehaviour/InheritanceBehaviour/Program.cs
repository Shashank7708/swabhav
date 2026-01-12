using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceBehaviour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Only Parent:");
            Parent p1 = new Parent(10);
            Console.WriteLine(p1.getvalue());

            Console.WriteLine("Parent AND Child Constructor");
            Child child1 = new Child(30);
            
            Console.WriteLine("Parent method using CHild Obj:"+child1.getvalue());
            

            Console.Read();
        }
    }
}
