using System.Reflection.Metadata;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = [10, 17, 25, 35, 52, 55, 62, 77, 90, 95];
            var result = BinarySearch(arr, 62);
            Console.WriteLine("Value found at index: "+result+" using Binary Search");
            int[] arr2 = [1, 3, 3, 5, 7];
            var resultUpperBound = FindUpperBound(arr2, 62);
            Console.WriteLine("Upper bound found at index: " + resultUpperBound + " using Binary Search");
            Console.WriteLine("Hello, World!");
            Console.Read();
        }
        private static int BinarySearch(int[] arr,int key)
        {
            int minVal = 0;
            int maxVal = arr.Length - 1;
            while (minVal <= maxVal)
            {
                          int mid= (minVal+maxVal)/2;
                if (key == arr[mid])
                    return mid++;
                else if (key < arr[mid])
                    maxVal = mid ;
                else
                    minVal = mid ;
            }
            return -1;
        }
        
        private static int FindUpperBound(int[] arr,int key)
        {
            int left = 0;
            int right = arr.Length;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] <= key)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }
    }
}
