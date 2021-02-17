using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find3ExceptionInCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int finderroor = 3;
            while (finderroor-- > 0)
            {
                try
                {
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    if (a < 0 || b < 0)
                    {
                        throw new NegativeNoException();
                    }
                    int c = a / b;
                    
                }
                catch (NegativeNoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("ENd of the program");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\n");
                    Console.WriteLine("GetType: "+e.GetType()+"\n");
                    Console.WriteLine("StackkTrace: "+e.StackTrace.ToString());


                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e.Message);
                }


                finally
                {
                    Console.WriteLine("End of the code");
                }
            }
            Console.ReadLine();
        }
    }
}
