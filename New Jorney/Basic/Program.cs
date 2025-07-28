using System;

namespace Basic
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            /*int a;
            float b;
            bool c;
            char d  ;
            string e=null;
            Console.WriteLine("Default values of Different type of Integers:");
            Console.WriteLine($"Integer: {a}\nFloat: {b}\nbool: {c}\nChar: {d}\nstring: {e}");
            */
            int[] arrint = new int[10];
            for (int i = 0; i < arrint.Length; i++)
            {
                Console.WriteLine(arrint[i]);
            }
            
                string[] strs = new string[] { "ab", "a" };
                if (strs.Length == 1)
                    Console.WriteLine(strs[0]);

                foreach (string s in strs)
                    if (String.IsNullOrEmpty(s))
                        Console.WriteLine("");

                for (int i = 0; i < strs[0].Length; i++)
                {
                    char ch = strs[0][i];
                    for (int j = 1; j < strs.Length; j++)
                    {
                        if (i >= strs.Length || strs[j][i] != ch)
                            Console.WriteLine(strs[0].Substring(0, i));
                    }
                }
                Console.WriteLine(""); 
    
            Dummy r = new Dummy();
            Console.WriteLine(r.w);
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }

    class Dummy
    {
       internal int q;
       internal int w;
    }
}