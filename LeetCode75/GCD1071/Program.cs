using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD1071
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GcdOfStrings("LEET", "CODE");
            GcdOfStrings1("Leet", "Code");
        }
        public static string GcdOfStrings(string str1, string str2)
        {

            int len1 = str1.Length;
            int len2 = str2.Length;
            int minLen = Math.Min(len1, len2);
            string shortStr, longStr;
            if (len1 == minLen)
            {
                shortStr = str1;
                longStr = str2;
            }
            else
            {
                shortStr = str2;
                longStr = str1;
            }
            bool foundShortString = false;
            string returnStr = "";
            for (int i = minLen; i > 0; i--)
            {
                int longLen = longStr.Length, j = 0;
                string temp = shortStr.Substring(0, i);
                while (j <= longLen && foundShortString != true)
                {
                    string strTemp = (j+i)>longLen?longStr.Substring(j):longStr.Substring(j,i);
                    //return longStr.Substring(j, i);
                    j = j + i;
                    if (strTemp != temp)
                    {
                        break;
                    }
                    if (j >= longLen)
                    {
                        foundShortString = true;
                        returnStr = strTemp;
                    }
                }
            }
            return returnStr;
        }
        public static string GcdOfStrings1(string str1, string str2)
        {
            if (!(str1 + str2).Equals(str2 + str1)) return "";

            int a = str1.Length, b = str2.Length;
            while (b > 0)
            {
                int temp = b;
                b = a % b;
                a = temp;      
            }

            return str1.Substring(0, a);
        }
    }
}
