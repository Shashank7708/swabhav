using System.Text;

namespace LeetCode345ReverseVowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "IceCreAm";
            ReverseVowelsApp1(s);
            Console.WriteLine("Hello, World!");
            Console.Read();
        }

        public static string ReverseVowelsApp1(string s)
        {
            char[] arr = s.ToCharArray();

            int i = 0, end = s.Length - 1;
            while (i < end)
            {

                while (i < end && !isVowel(arr[i]))
                {
                    i++;
                }

                while (i < end && !isVowel(arr[end]))
                {
                    end--;
                }

                (arr[i], arr[end]) = (arr[end], arr[i]);

                i++; end--;
            }
            return new String(arr);
        }

        static bool isVowel(char c)
        {
            return c is 'a' or 'A' or 'e' or 'E' or 'i' or 'I' or 'o' or 'O' or 'u' or 'U';
        }


        public static string ReverseVowelsApp2(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> vowelStack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'A' || s[i] == 'e' || s[i] == 'E' || s[i] == 'i' || s[i] == 'I' || s[i] == 'o' || s[i] == 'O' || s[i] == 'u' || s[i] == 'U')
                    vowelStack.Push(s[i]);

            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'A' || s[i] == 'e' || s[i] == 'E' || s[i] == 'i' || s[i] == 'I' || s[i] == 'o' || s[i] == 'O' || s[i] == 'u' || s[i] == 'U')

                    //char replaceChar=vowelStack.Pop();
                    sb.Append(vowelStack.Pop());


                else
                {
                    sb.Append(s[i]);
                }

            }
            return sb.ToString();
        }

    }
}
