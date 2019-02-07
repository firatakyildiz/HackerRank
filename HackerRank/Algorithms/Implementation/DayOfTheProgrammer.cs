using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/day-of-the-programmer/problem
    /// Difficulty : Easy
    /// </summary>
    public static class DayOfTheProgrammer
    {
        public static void Solve()
        {
            int year = Convert.ToInt32(Console.ReadLine().Trim());
            string result = dayOfProgrammer(year);
            Console.WriteLine(result);
        }

        private static string dayOfProgrammer(int year)
        {
            const int transitionYear = 1918;
            DateTime date;
            if (year < transitionYear)
            {
                date = year % 4 == 0 ? new DateTime(year, 9, 12) : new DateTime(year, 9, 13);
            }
            else if (year == transitionYear)
            {
                date = new DateTime(1918, 9, 26);
            }
            else
            {
                date = DateTime.IsLeapYear(year) ? new DateTime(year, 9, 12) : new DateTime(year, 9, 13);
                
            }
            return date.ToString("dd.MM.yyyy");
        }
    }
}
