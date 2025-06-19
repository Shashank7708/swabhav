namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo f = new Foo();
            f.FooEvent += WriteAbc;
            f.FooEvent += WriteXYZ;
            f.Run();
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }

        static void WriteAbc()
        {
            Console.WriteLine("Hello ABC");
        }
        static void WriteXYZ()
        {
            Console.WriteLine("Hello XYZ");
        }

    }
}