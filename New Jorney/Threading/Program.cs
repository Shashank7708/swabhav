namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WriteCurrentThread();
            Console.WriteLine("Hello, World!");
            //WriteCurrentThread();

            Thread t1 = new Thread(WriteCurrentThread2);
            Thread t2 = new Thread(WriteCurrentThread2);
            
            t1.Priority=ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;
            Thread.CurrentThread.Priority= ThreadPriority.Normal;

            t1.Start();
            t2.Start();
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello WOrld {0}", i);
            }
            Console.ReadKey();
        }
        static void WriteCurrentThread()
        {
            Thread.CurrentThread.Name = "New Thread";
            Console.WriteLine(Thread.CurrentThread.ToString());

            Console.WriteLine(Thread.CurrentThread.Name);

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId); 
        }
        static void WriteCurrentThread2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(3000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
