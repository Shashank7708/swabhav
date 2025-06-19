using System.Text;

namespace LeetCode151ReverseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "the sky is blue";
            string reverseWords=ReverseWords(s);
            Console.WriteLine(reverseWords);
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }

        public static  string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();
            s = s.Trim();
            while (s.Contains("  "))
                s = s.Replace("  ", " ");

            string[] arr = s.Split(" ");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sb.Append(arr[i]).Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}
