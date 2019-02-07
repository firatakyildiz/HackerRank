using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/fair-rations/problem
    /// Difficulty : Easy
    /// Solution : Initial numbers are useless after we know they are even or odd.
    /// Starting from the beginning, check each element for evenness. If not, swap it and the one
    /// after it. No need to turn back since we want all the elements to be even, and returning
    /// back will only break this constraint. If the last element is odd when we reach it, there
    /// is no possible way to make the list all even. 
    /// </summary>
    public static class FairRations
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var array = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x) % 2 == 0);
            var count = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (!array[i])
                {
                    count += 2;
                    array[i + 1] = !array[i + 1];
                }
            }

            Console.WriteLine(array[array.Length - 1] ? count.ToString() : "NO");
        }
    }
}
