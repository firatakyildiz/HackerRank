using System;
using System.Linq;

namespace HackerRank.OneWeekPreparationKit.Day1
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-plus-minus/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class PlusMinus
    {
        public static void Solve()
        {
            var n = Convert.ToInt32(Console.ReadLine().Trim());
            var arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(number => Convert.ToInt32(number)).ToList();

            var negativeCount = 0;
            var zeroCount = 0;
            var positiveCount = 0;

            foreach (var number in arr)
            {
                if (number == 0)
                    zeroCount++;
                else if (number > 0)
                    positiveCount++;
                else if (number < 0)
                    negativeCount++;
            }

            var total = positiveCount + zeroCount + negativeCount;

            Console.WriteLine(((float)positiveCount / total).ToString("F6"));
            Console.WriteLine(((float)negativeCount/ total).ToString("F6"));
            Console.WriteLine(((float)zeroCount / total).ToString("F6"));
        }
    }
}
