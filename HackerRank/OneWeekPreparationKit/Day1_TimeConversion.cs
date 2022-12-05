using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-time-conversion/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class Day1_TimeConversion
    {
        public static void Solve()
        {
            var input = Console.ReadLine();
            var amPm = input.Substring(8, 2);

            var hour = int.Parse(input.Substring(0, 2));
            hour %= 12;
            
            if (amPm == "PM")
                hour += 12;

            var result = (hour < 10 ? "0" : "") + hour + input.Substring(2, 6); 
            Console.WriteLine(result);
        }
    }
}
