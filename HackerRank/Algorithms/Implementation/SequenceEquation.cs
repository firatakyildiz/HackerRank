using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/permutation-equation/problem
    /// Difficulty : Easy
    /// </summary>
    public static class SequenceEquation
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[arr[arr[arr[i] - 1] - 1] - 1] = arr[i];
            }

            foreach (var i in newArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
