using System.Text;

namespace LeetCode345ReverseVowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "IceCreAm";
            ReverseVowels(s);
            Console.WriteLine("Hello, World!");
            Console.Read();
        }

        public static string ReverseVowels(string s)
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
