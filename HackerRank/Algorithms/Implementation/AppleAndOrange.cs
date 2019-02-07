using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/apple-and-orange/problem
    /// Difficulty : Easy
    /// </summary>
    public static class AppleAndOrange
    {
        public static void Solve()
        {
            string[] st = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(st[0]);
            int t = Convert.ToInt32(st[1]);
            string[] ab = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(ab[0]);
            int b = Convert.ToInt32(ab[1]);
            string[] mn = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(mn[0]);
            int n = Convert.ToInt32(mn[1]);
            int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));
            int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));
            countApplesAndOranges(s, t, a, b, apples, oranges);
        }

        private static void countApplesAndOranges(int houseStart, int houseEnd, int appleTreeLocation, int orangeTreeLocation, int[] apples, int[] oranges)
        {
            var numberOfApples = apples.Count(x => appleTreeLocation + x >= houseStart && appleTreeLocation + x <= houseEnd);
            var numberOfOranges = oranges.Count(x => orangeTreeLocation + x >= houseStart && orangeTreeLocation + x <= houseEnd);
            Console.WriteLine(numberOfApples);
            Console.WriteLine(numberOfOranges);
        }
    }
}
