using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/equality-in-a-array/problem
    /// Difficulty : Easy
    /// </summary>
    public static class EqualizeTheArray
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var map = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!map.ContainsKey(item))
                    map[item] = 1;
                else
                    map[item] = map[item] + 1;
            }

            var result = arr.Length - map.Max(x => x.Value);
            Console.WriteLine(result);
        }
    }
}
