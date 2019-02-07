using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/migratory-birds/problem
    /// Difficulty : Easy
    /// </summary>
    public static class MigratoryBirds
    {
        public static void Solve()
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = migratoryBirds(arr);
            Console.WriteLine(result);
        }

        private static int migratoryBirds(List<int> list)
        {
            var counts = new int[5];
            foreach (var item in list)
            {
                counts[item - 1]++;
            }
            var maxIndex = 0;
            var maxValue = 0;
            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] > maxValue)
                {
                    maxValue = counts[i];
                    maxIndex = i;
                }
            }
            return maxIndex + 1;
        }
    }
}
