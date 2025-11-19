namespace LeetCode443CompressString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            char[] s = ['a', 'a','b','b','c','c','c'];
            var result = Compress(s);
            Console.Write(result);
            Console.Read();
        }

        public static int Compress(char[] chars)
        {
            int charCount = 1; int uniqueCount = 0;

            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i] == chars[i - 1])
                {
                    charCount++;
                }
                else
                {
                    chars[uniqueCount++] = chars[i - 1];
                    if (charCount > 1)
                        chars[uniqueCount++] = (char)charCount;

                    charCount = 1;
                }
            }
            return uniqueCount - 1;
        }
    }
}
