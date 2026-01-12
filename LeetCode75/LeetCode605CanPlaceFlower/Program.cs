namespace LeetCode605CanPlaceFlower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] flowerbed = [1, 0, 0, 0, 1];
            int n = 1;
            var result=CanPlaceFlowers(flowerbed, n);
            Console.WriteLine(result);
            Console.WriteLine("Hello, World!");
            Console.Read();
        }

        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {

            int[] tempArray = flowerbed;
            for (int i = 0; i < tempArray.Length; i++)
            {
                bool left= i==0 || tempArray[i-1]==0? true:false;
                bool right=i==tempArray.Length-1 || tempArray[i+1]==0? true:false;
                if (left && right && tempArray[i] == 0)
                {
                    n--;
                    tempArray[i] = 1;
                }
            }
            return n <= 0;
        }
    }
}
