using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcastingAndDowncasting
{
    class Child:Parent
    {
        internal override void Print()
        {
            Console.WriteLine(" I am in Child");
            
        }
        public void Parent1()
        {
            Console.WriteLine("I am in child class");
            
        }
        public void OnlyInChild()
        {
            Console.WriteLine(" I am in only Cild");
        }
        private void ChlidPrivateMethod()
        {
            Console.WriteLine("I am CHild Private Method");
        }
     protected override void PrintProtectedMethod()
        {
            Console.WriteLine("I overide Parent method in child");
        }
       


    }
}
