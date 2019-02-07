using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/the-birthday-bar/problem
    /// Difficulty : Easy
    /// Solution : Keep a sliding window with fixed length. Add new values and subtract oldest ones.
    /// </summary>
    public static class BirthdayChocolate
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            string[] dm = Console.ReadLine().TrimEnd().Split(' ');
            int d = Convert.ToInt32(dm[0]);
            int m = Convert.ToInt32(dm[1]);
            int result = birthday(s, d, m);
            Console.WriteLine(result);
        }

        private static int birthday(List<int> list, int day, int month)
        {
            if (list.Count < month)
                return 0;
            var count = 0;
            var windowTotal = 0;
            for (int index = 0; index < month; index++)
            {
                windowTotal += list[index];
            }
            if (windowTotal == day)
                count++;
            for (int index = month; index < list.Count; index++)
            {
                windowTotal += list[index];
                windowTotal -= list[index - month];
                if (windowTotal == day)
                    count++;
            }
            return count;
        }
    }
}
