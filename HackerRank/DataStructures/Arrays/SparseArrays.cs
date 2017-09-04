using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/sparse-arrays
    /// Difficulty : Medium
    /// </summary>
    class SparseArrays
    {
        public static void Solve() {
            var len = Convert.ToInt32(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < len; i++)
            {
                list.Add(Console.ReadLine());
            }
            var queryLength = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < queryLength; i++)
            {
                var query = Console.ReadLine();
                Console.WriteLine(list.FindAll(x => x == query).Count);
            }
        }
    }
}
