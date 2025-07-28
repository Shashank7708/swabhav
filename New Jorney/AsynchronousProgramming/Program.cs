using System.Diagnostics;
using System.Numerics;

namespace AsynchronousProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var r= MyMethodAsync();
            Console.Write(r+"");
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }
            Console.Read();
        }

        public static async Task<int> MyMethodAsync()
        {
            Task<char> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            char result =await  longRunningTask;
            //use the result 
            Console.WriteLine(result);
            return 0;
        }

        public static  async Task<char> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            BigInteger i = 0;
          //  while (i <= 1000000000)
            //    i++;
            await Task.Delay(1000); // 1 second delay
            return 'A';
        }

    }
}
