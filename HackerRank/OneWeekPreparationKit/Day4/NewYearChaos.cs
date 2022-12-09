using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day4
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-new-year-chaos/problem
    /// Difficulty : Easy
    /// Solution : See inline comments
    /// </summary>
    public static class NewYearChaos
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var length = Convert.ToInt32(Console.ReadLine().Trim());
                var queue = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();
                minimumBribes(queue);
            }
        }

        private static void minimumBribes(List<int> queue)
        {
            var bribes = 0;

            for (var i = 0; i < queue.Count; i++)
            {
                // each person can move at most 2 positions forward.
                if (queue[i] - (i + 1) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                // for each person, count how many persons are ahead of it
                // in the range where it should be and where it is now
                for (var j = Math.Max(0, queue[i] - 2); j < i; j++)
                {
                    if (queue[j] > queue[i]) bribes++;
                }
            }
            Console.WriteLine(bribes);
        }
    }
}
