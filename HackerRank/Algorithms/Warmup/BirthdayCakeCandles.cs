using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/birthday-cake-candles/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BirthdayCakeCandles
    {
        public static void Solve()
        {
            int arCount = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = birthdayCakeCandles(ar);
            Console.WriteLine(result);
        }

        private static int birthdayCakeCandles(int[] arr)
        {
            var map = new Dictionary<int,int>();
            var maxHeight = 0;
            foreach (var i in arr)
            {
                if (i > maxHeight)
                    maxHeight = i;
                if (map.ContainsKey(i))
                    map[i] = map[i] + 1;
                else
                {
                    map[i] = 1;
                }
            }
            return map[maxHeight];
        }
    }
}
