using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHighestAltitude1732
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -5, 1, 5, 0, -7 };
            var highestAlt = LargestAltitude(arr);
            Console.WriteLine(highestAlt);
            Console.Read();
        }
        public static int LargestAltitude(int[] gain)
        {
            int currentVal = 0;
            int maxVal = 0;
            foreach (int g in gain)
            {
                currentVal = currentVal + g;
                maxVal = Math.Max(currentVal, maxVal);
            }
            return maxVal;
        }

        /*public static int LargestAltitude(int[] gain) {
            int len=gain.Length;
            int[] arr=new int[len+1];
            arr[0]=0;
            int maxVal=arr[0];
            for(int i=0;i<len;i++){
                arr[i+1]=arr[i]+gain[i];
                maxVal=Math.Max(arr[i+1],maxVal);
            }
            return maxVal;

        }*/
    }
}
