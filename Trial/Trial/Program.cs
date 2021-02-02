using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = " s es s     %hello 3     y    ";

            Console.WriteLine(name);
            Console.WriteLine(name.Trim());
            
            Console.WriteLine(name.TrimStart());
            Console.WriteLine(name.TrimEnd());
            Console.WriteLine(name.Trim(new char[] { 's', 'y',' '}));

            Console.WriteLine("\n\n\nReplacemethods");
            string name2 = "Hello my name is shashank";
            string name3 = "Hello my name is Romy";
            Console.WriteLine("Original String= " + name2);
            Console.WriteLine("Formated String= "+name2.Replace('a', 'w')+"\n");
            Console.WriteLine("Original String= " + name3);
            Console.WriteLine("Formated String= "   +name3.Replace("Hello", "World"));

            Console.ReadLine();  
        }
    }
}
