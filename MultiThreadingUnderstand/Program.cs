using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingUnderstand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Thread t1 = new Thread(PrintCurrentThread1);
            t1.Name = "T1";
            t1.Start();
            
            PrintCurrentThread1();
            PrintCurrentThread2();
            Console.ReadLine();
        }
        public static void PrintCurrentThread1()
        {
            Console.WriteLine("Method 1 Before Sleep= "+Thread.CurrentThread.Name);
            Thread.Sleep(3000);
            Console.WriteLine("Method 1 After Sleep= " + Thread.CurrentThread.Name);

        }
        public static void PrintCurrentThread2()
        {
            Console.WriteLine("Method 2= " + Thread.CurrentThread.ManagedThreadId);
        }

        public static void ThreadJoin()
        {
            int[] arr = { 1, 3, 4, 5, 3, 34, 23, 2, 4, 5 };
            int sum1=0, sum2=0, sum3=0, sum4=0;
            int noOfthread = 4;
            Thread[] threads = new Thread[noOfthread];
            int segmentLen = arr.Length / noOfthread;

            threads[0] = new Thread(() => sum1 = SumSegment(arr, 0, segmentLen));
            threads[2] = new Thread(() => sum2 = SumSegment(arr, segmentLen,2* segmentLen));
            threads[3] = new Thread(() => sum3 = SumSegment(arr, 2* segmentLen, 3* segmentLen));
            threads[4] = new Thread(() => sum4 = SumSegment(arr, 3* segmentLen, arr.Length));

            foreach(var t in threads) { t.Start(); }

            foreach (var t in threads) { t.Join(); }  
            /// Join blocks the main thread. Here the main thread is ThreadJoin() method. 

            Console.WriteLine("Sum is " + (sum1 + sum2 + sum3 + sum4));// This will only execute after the above threads are executed
            //If only thread[0] was join, the main thread would have executed after thread[0] irrespective of all other threads
        }

        public static int SumSegment(int[] arr,int start,int end)
        {
            int sum=0;
            for(int i=start; i < end; i++)
            {
                Thread.Sleep(50);
                sum += arr[i];
            }
            return sum;
        }

    }
}
