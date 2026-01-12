using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcastingAndDowncasting
{
    class Parent
    {
        internal virtual void Print()
        {
            Console.WriteLine("Hello I am Parent");
        }
        public void Parent1()
        {
            Console.WriteLine("I am in Parent Class");
        }
       protected virtual void PrintProtectedMethod()
        {
            Console.WriteLine("I am protected method of parent");
        }

        internal void OnlyInParent()
        {
            Console.WriteLine("I am Only in parent");
        }
    }
}
