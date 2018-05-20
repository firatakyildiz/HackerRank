using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Queues
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/truck-tour/problem
    /// Difficulty : Hard
    /// Explanation : This problem is almost identical to max contiguous subarray sum problem. 
    /// </summary>
    public class TruckTour
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] petrolpumps = new int[n][];
            for (int petrolpumpsRowItr = 0; petrolpumpsRowItr < n; petrolpumpsRowItr++)
            {
                petrolpumps[petrolpumpsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp));
            }
            int result = truckTour(petrolpumps);
            Console.WriteLine(result);
        }

        private static int truckTour(int[][] petrolPumps)
        {
            var len = petrolPumps.Length;
            var arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = petrolPumps[i][0] - petrolPumps[i][1];
            }

            var frontIndex = 0;
            var backIndex = 0;
            var sum = 0;
            var stationCount = 0;

            while (stationCount != len)
            {
                // add station
                sum += arr[frontIndex];
                frontIndex = (frontIndex + 1) % len;
                stationCount++;

                // remove station
                while (sum < 0)
                {
                    sum -= arr[backIndex];
                    backIndex = (backIndex + 1) % len;
                    stationCount--;
                }
            }
            return backIndex;
        }
    }
}
