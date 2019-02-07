using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Advanced
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/kindergarten-adventures/problem
    /// Difficulty : Medium
    /// Solution : Each student K succeeds or fails depending on where teacher started.
    /// If the teacher started with the student after him(K + 1), he succeeds.
    /// If the teacher started from any student between K - T and him, he fails.
    /// Keep track of number of fails and successes in an array, then compute the answer.
    /// </summary>
    public static class KindergartenAdventures
    {
        public static void Solve()
        {
            int tCount = Convert.ToInt32(Console.ReadLine());
            int[] t = Array.ConvertAll(Console.ReadLine().Split(' '), tTemp => Convert.ToInt32(tTemp));
            int id = solve(t);
            Console.WriteLine(id);
        }

        private static int solve(int[] arr)
        {
            var len = arr.Length;
            var differences = new int[len];
            for (int i = 0; i < len; i++)
            {
                // this will always succeed or fail. no need to take into calculation.
                if (arr[i] == 0 || arr[i] == len)
                    continue;
                // for each value, calculate the start and end times when will this succeed
                // failure end
                var failureEnd = i + 1;
                var failureStart = i - arr[i] + 1;
                if (failureStart < 0)
                    failureStart += len;
                if (failureEnd >= len)
                    failureEnd -= len;
                differences[failureEnd]++;
                differences[failureStart]--;
            }

            var globalTotal = -1;
            var tempTotal = 0;
            var index = 0;
            for (int i = 0; i < len; i++)
            {
                tempTotal += differences[i];
                if (tempTotal > globalTotal)
                {
                    globalTotal = tempTotal;
                    index = i;
                }
            }
            return index + 1;
        }
    }
}
