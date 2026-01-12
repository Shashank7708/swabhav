
namespace Array_DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 9, 4, 8, 6 };
            Console.WriteLine(arr);   //Print Address of memory location 

            Console.WriteLine(arr.ToString()); /// Same output as above
            Console.WriteLine(string.Join("  ", arr)); //It will print the array and concat with 1st parameter specified

            int[] arra = new[] { 1,3,4,3};
            int[] arr2 = new int[10];
            Array.Fill(arr2, 5);            ///Fill the array with required digit
            Console.WriteLine(string.Join("", arr2));


            Array.Sort(arr);
            Console.WriteLine("Sorted Array arr= " + (string.Join(" ",arr)) );

            Array.Reverse(arr);
            Console.WriteLine("Reverse Array arr= " + (string.Join(" ", arr)));

            int[][] arr2D = {new int[]{ 1, 4, 2, 50 },new int[] { 5, 2, 1, 20 }, new int[]{ 7, 9, 8, 30 } };

            var s = arr2D.OrderBy(x => x[3]).ToArray();
            for(int i=0;i<s.Length;i++)
            {
                Console.WriteLine("Sorted Array arr2D= " + (string.Join(" ", s[i])));

            }

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
