using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/save-the-prisoner/problem
    /// Difficulty : Easy
    /// </summary>
    public static class SaveThePrisoner
    {
        public static void Solve()
        {
            var numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var result = (arr[1] + arr[2] - 1);
                result = (result - 1) % arr[0] + 1;
                Console.WriteLine(result);
            }
        }
    }
}
