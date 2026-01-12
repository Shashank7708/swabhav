using System;

namespace WelcomeConsoleCoreVs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var i = args[0].ToString();
            Colorful.Console.WriteAscii($"Hello {i}");
        }
    }
}
