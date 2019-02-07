using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/minimum-distances/problem
    /// Difficulty : Easy
    /// </summary>
    public static class MinimumDistances
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var lastIndices = new Dictionary<int, int>();
            var minimumDistance = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!lastIndices.ContainsKey(arr[i]))
                    lastIndices[arr[i]] = i;
                else
                {
                    var distance = i - lastIndices[arr[i]];
                    if (distance < minimumDistance)
                        minimumDistance = distance;
                    lastIndices[arr[i]] = i;
                }
            }

            Console.WriteLine(minimumDistance == int.MaxValue ? -1 : minimumDistance);
        }
    }
}
