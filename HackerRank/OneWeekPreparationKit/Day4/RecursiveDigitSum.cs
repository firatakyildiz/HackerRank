using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day4
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-recursive-digit-sum/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class RecursiveDigitSum
    {
        public static int superDigit(string input, int k)
        {
            var total = 0L;
            while (true)
            {
                total = input.Aggregate(0, (sum, next) => sum += next - '0');
                if (k > 0)
                {
                    total *= k;
                    k = 0;
                }
                if (total < 10)
                    break;
                input = total.ToString();
            }
            return (int)total;
        }
    }
}
