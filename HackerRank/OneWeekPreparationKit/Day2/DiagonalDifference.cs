using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day2
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-diagonal-difference/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class DiagonalDifference
    {
        public static void Solve()
        {
            var n = Convert.ToInt32(Console.ReadLine().Trim());
            var arr = new List<List<int>>();

            for (var i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            var firstDiagonalTotal = 0;
            var secondDiagonalTotal = 0;
            for (var i = 0; i < n; i++)
            {
                firstDiagonalTotal += arr[i][i];
                secondDiagonalTotal += arr[i][n - i - 1];
            }
            Console.WriteLine(Math.Abs(firstDiagonalTotal - secondDiagonalTotal));
        }
    }
}
