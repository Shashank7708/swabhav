
namespace FIzzBuzz
{
    interface IFizzBuzz
    {
        void Write(string output);
    }
    internal class ConsoleFizzBuzz: IFizzBuzz
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
    class FIzzBuzz
    {
        private readonly IFizzBuzz _buzz;
        public FIzzBuzz(IFizzBuzz fizzBuzz)
        {
            this._buzz = fizzBuzz;
        }
        internal void Run(int from, int to)
        {
            for(int i = 0; i <= to; i++)
            {
                bool div3 = i % 3 == 0;
                bool div5= i % 5 == 0;
                if (div3 && div5)
                    _buzz.Write("FizzBuzz");

                else if (div3)
                    _buzz.Write("Fizz");

                else if (div5)
                    _buzz.Write("Buzz");
                else
                    _buzz.Write(i.ToString());
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FIzzBuzz fIzzBuzz = new FIzzBuzz(new ConsoleFizzBuzz());
            fIzzBuzz.Run(0, 100);
            Console.ReadKey();

        }
    }
}
