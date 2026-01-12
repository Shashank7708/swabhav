using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterFaceEg1
{
    class MyClass1 : Interface1
    {   
        int Interface1.GetValue { set; get; }
       
         void Interface1.method2()
        {
            Console.WriteLine("Method2 of interface");
        }
        void Interface1.Method1()
        {
            Console.WriteLine("Method2");
        }
        




    }

  
}
