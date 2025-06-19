namespace LeetCode1431
{
    internal class Program
    {//Kids With the Greatest Number of Candies
        static void Main(string[] args)
        {
            KidsWithCandies(new int[]{4, 3, 2, 3}, 1);
            Console.WriteLine("Hello, World!");
        }

        public IList<bool> KidsWithCandiesApp1(int[] candies, int extraCandies)
        {
            int MaxVal = candies.Max();
            List<bool> returnList = new List<bool>();
            foreach (int i in candies)
            {
                if (i + extraCandies >= MaxVal)
                    returnList.Add(true);
                else
                    returnList.Add(false);


            }
            return returnList;
        }

        public IList<bool> KidsWithCandiesApp2(int[] candies, int extraCandies)
        {
            int MaxVal = candies.Max();
            List<bool> returnList = new List<bool>();
            foreach (int i in candies)
            {
                    returnList.Add(i + extraCandies >= MaxVal);
                
            }
            return returnList;
        }

    }
}
