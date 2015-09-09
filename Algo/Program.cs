using System;

namespace Algo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = GenerateRandomIntArray(10000);
            Sort<int>.QuickSortV2(a);
            Console.WriteLine(Sort<int>.IsSorted(a));
        }

        static int[] GenerateRandomIntArray(int n)
        {
            Random r = new Random();
            var items = new int[n];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = r.Next();
            }

            return items;
        }
    }
}
