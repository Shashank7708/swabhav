using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAStringIntoK2138
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abcdefghij";
            DivideString(s, 3, 'x');
            Console.WriteLine(s);
            Console.ReadLine();

        }
        public static string[] DivideString(string s, int k, char fill)
        {
            int len = s.Length;
            int arrLen = len % k == 0 ? len / k : ((len / k) + 1);
            string[] arr = new string[arrLen];
            int counter = 0;
            bool isCompleted = false;
            int i = 0;
            while (!isCompleted)
            {
                if ((i + k) < s.Length)
                {
                    arr[counter++] = s.Substring(i, k);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(s.Substring(i, len - i));
                    int temp = len - i ;
                    int remainingLen = k - temp;
                    int q = 0;
                    while (q < remainingLen)
                    {
                        sb.Append(fill);
                        q++;
                    }
                    arr[counter++] = sb.ToString();
                    isCompleted = true;
                }
                i = i + k;
            }
            return arr;
        }
    }
}
