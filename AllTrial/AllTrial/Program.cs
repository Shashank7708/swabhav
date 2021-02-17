using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AllTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var line = File.ReadAllLines(@"C:\swabhav\reading.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    Console.WriteLine(line[i]);
                }
            }
   
     
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
            }
            
            finally
            {
                int i = 10;
                Console.WriteLine("In Finally Printint value of i :{0}", i);
            }
        

            int j=20;
            Console.WriteLine("Outside Finally :  J={0}", j);

            Console.ReadLine();
        }
    }
}
