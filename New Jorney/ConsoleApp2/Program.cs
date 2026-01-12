namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var a = "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101";
            var b = "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011";
            Console.WriteLine(AddBinary(a, b));
            Console.ReadLine();
        }

        public static string AddBinary(string a, string b)
        {
            uint aValue, bValue, sumAB;
            aValue = ValueFromBinary(a);
            bValue = ValueFromBinary(b);
            sumAB = aValue + bValue;

            if (sumAB == 0)
                return 0.ToString();
            return BinaryFromValue(sumAB);
        }

        public static string BinaryFromValue(uint value)
        {
            Stack<uint> stack = new Stack<uint>();
            uint tempVal = value;
            uint multiple2 = 1;
            string returnVal = "";
            while (tempVal >= multiple2)
            {
                stack.Push(multiple2);
                multiple2 = multiple2 * 2;
            }

            while (stack.Count > 0)
            {
                uint temp = stack.Pop();
                if (temp <= tempVal)
                {
                    returnVal += "1";
                    tempVal = tempVal - temp;
                }
                else
                    returnVal += "0";

            }
            return returnVal;
        }
        public static uint ValueFromBinary(string s)
        {
            uint returnVal = 0;
            uint multiple_2 = 1;
            if (s[s.Length - 1] == '1')
                returnVal = returnVal + 1;

            for (int i = s.Length - 2; i >= 0; i--)
            {
                multiple_2 = multiple_2 * 2;
                if (s[i] == '1')
                    returnVal = returnVal + multiple_2;
            }

            return returnVal;
        }
    }
}
