using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/beautiful-triplets/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BeautifulTriples
    {
        public static void Solve()
        {
            var difference = int.Parse(Console.ReadLine().Split()[1]);
            var array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + difference != array[j])
                        continue;
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if (array[j] + difference != array[k])
                            continue;
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
