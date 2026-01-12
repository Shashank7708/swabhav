using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcastingAndDowncasting
{

    //We cannot Change the access Modifir of method from parent to child
    //eg in parent : public void GetInfo() and In Child : private/internal/protected void GetInfo() NOT POSSIBLE
    //only public void GetInfo()  not Possible
    class Program
    {
        static void Main(string[] args)
        {
            Parent p1 = new Parent();
            p1.Print();
            p1.Parent1();
            
            Console.WriteLine("Child Object");
            Child c1 = new Child();
            c1.Print();
            c1.Parent1();
            
            Type t1 = c1.GetType();
            Console.WriteLine(t1);
            Console.WriteLine("###################################################");
            Console.WriteLine("Parent refernce to child obj:");
            Parent pc1 = new Child();
            pc1.Print();
            pc1.Parent1();
            pc1.OnlyInParent();
            
            Console.WriteLine("###################################################");
            Console.WriteLine("Childreference to parent obj");
            Parent p = new Child();
            Child c = (Child)p;
            c.Print();
            c.Parent1();
            c.OnlyInChild();
            c.OnlyInParent();
           
            



            Console.ReadLine();
        }
    }
}
