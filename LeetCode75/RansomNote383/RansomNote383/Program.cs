using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RansomNote383
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var r1 = CanConstruct("a", "a");
            var r2 = CanConstruct("aaab", "abaa");
            Console.WriteLine($"r1={r1} \t r2={r2}");
            Console.ReadLine();
        }
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            //Beats 78.15%
            int[] chArray = new int[26];
           // Array.Fill(chArray, 0);
            foreach (var i in magazine)
                chArray[i - 'a']++;

            foreach (var i in ransomNote)
            {
                chArray[i - 'a']--;
            }
            foreach (var i in chArray)
            {
                if (i < 0)
                    return false;
            }
            return true;
            /*
            //Beats Only 72%
            List<char> list=new List<char>(magazine);
            for(int i=0;i<ransomNote.Length;i++){
                if(!list.Remove(ransomNote[i]))
                    return false;
            }
            return true;
            */
        }
    }
}
