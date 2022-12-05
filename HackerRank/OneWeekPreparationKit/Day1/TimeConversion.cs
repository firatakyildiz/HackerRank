using System;

namespace HackerRank.OneWeekPreparationKit.Day1
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-time-conversion/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class TimeConversion
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
