using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler004/problem
    /// Difficulty : Easy
    /// Solution : Find the next palindrome, check if it can be written as the product of 2 different 3 digit numbers
    /// </summary>
    public static class _4
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32((Console.ReadLine()));
                
                while (true)
                {
                    number = getNextLowerPalindrome(number);
                    if (isProductOfTwo3DigitNumbers(number))
                        break;
                }
                Console.WriteLine(number);
            }
        }

        private static void mirrorRightHalfOfStringBuilder(StringBuilder builder)
        {
            if (builder.Length == 3)
                builder.Length = 6;
            builder[3] = builder[2];
            builder[4] = builder[1];
            builder[5] = builder[0];
        }

        private static int getNextLowerPalindrome(int number)
        {
            var builder = new StringBuilder(number.ToString());
            mirrorRightHalfOfStringBuilder(builder);
            var candidate = int.Parse(builder.ToString());

            if (candidate < number)
                return candidate;

            candidate = int.Parse(builder.ToString().Substring(0, 3));
            candidate--;
            builder = new StringBuilder(candidate.ToString());
            mirrorRightHalfOfStringBuilder(builder);
            candidate = int.Parse(builder.ToString());

            return candidate;
        }

        private static bool isProductOfTwo3DigitNumbers(int number)
        {
            for (var i = 100; i < 1000; i++)
            {
                var dividend = number / i;
                if (number % i == 0 && dividend > 99 && dividend < 1000)
                    return true;
            }
            return false;
        }
    }
}
