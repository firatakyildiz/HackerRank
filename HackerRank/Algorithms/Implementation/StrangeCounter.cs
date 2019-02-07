using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/strange-code/problem
    /// Difficulty : Easy
    /// Solution : Just brute-force it.
    /// </summary>
    public static class StrangeCounter
    {
        public static void Solve()
        {
            var input = long.Parse(Console.ReadLine());
            var deduction = 3L;
            while (input > deduction)
            {
                input -= deduction;
                deduction *= 2;
            }
            Console.WriteLine(deduction - input + 1);
        }
    }
}
