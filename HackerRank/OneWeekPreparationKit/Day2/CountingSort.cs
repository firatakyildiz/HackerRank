using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day2
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-countingsort1/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class CountingSort
    {
        public static void Solve()
        {
            var n = Convert.ToInt32(Console.ReadLine().Trim());
            var arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            var countingSortArr = new int[100];
            foreach (var i in arr)
            {
                countingSortArr[i]++;
            }
            Console.WriteLine(string.Join(' ', countingSortArr));
        }
    }
}
