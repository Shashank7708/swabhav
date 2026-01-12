namespace LeetCode58
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var len = LengthOfLastWord("a ");
            Console.WriteLine("Length of Last Word= " + len);
            var len1 = LengthOfLastWordUsingBuiltIn("a ");
            Console.WriteLine("Length of Last Word= " + len1);
            Console.ReadLine();

        }

        internal static int LengthOfLastWordUsingBuiltIn(string s)
        {
            int len = 0;
            s = s.Trim();
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ') 
                    break;

                len++;
            }
            return len;
        }
        internal static int LengthOfLastWord(string s)
        {
            int lenToReturn = 0, temp = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {

                if (s[i] != ' ')
                    break;


                temp++;

            }
            for (int i = s.Length - 1 - temp; i >= 0; i--)
            {

                if (s[i] == ' ')
                    break;
                lenToReturn++;
            }
            return lenToReturn;
        }
    }
}
