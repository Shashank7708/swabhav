using System.Text;

namespace LeetCode1768
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3 % 6;
            string s1 = "";
            string s2 = null;
            var result = MergeTwoStringAlternativelyApp1(s1, s2);

            Console.WriteLine(result);
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
        private static string MergeTwoStringAlternativelyApp1(string s1,string s2)
        {
            int counter = 0;

            if (string.IsNullOrEmpty(s1))   return s2;
            else if(string.IsNullOrEmpty(s2)) return s1;

            int s1Len = s1.Length;
            int s2Len = s2.Length;
            StringBuilder sb=new StringBuilder();
            while (counter < s1Len || counter < s2Len)
            {
                if(counter < s1Len)
                    sb.Append(s1[counter]);
                if(counter<s2Len)
                    sb.Append(s2[counter]);
                counter++;
            }
            return sb.ToString();
        }

        //More Optimized
        private static string MergeTwoStringAlternativelyApp2(string word1, string word2)
        {
            int counter = 0;

            StringBuilder sb = new StringBuilder();
            while (counter < word1.Length && counter < word2.Length)
            {
                sb.Append(word1[counter]);
                sb.Append(word2[counter]);

                counter++;
            }
            if (counter < word1.Length)
                sb.Append(word1.Substring(counter, word1.Length - counter));

            else if (counter < word2.Length)
                sb.Append(word2.Substring(counter, word2.Length - counter));

            return sb.ToString();
        }
    }
}
