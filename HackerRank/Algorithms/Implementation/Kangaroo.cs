using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/kangaroo/problem
    /// Difficulty : Easy
    /// </summary>
    public static class Kangaroo
    {
        public static void Solve()
        {
            string[] x1V1X2V2 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(x1V1X2V2[0]);
            int v1 = Convert.ToInt32(x1V1X2V2[1]);
            int x2 = Convert.ToInt32(x1V1X2V2[2]);
            int v2 = Convert.ToInt32(x1V1X2V2[3]);
            string result = kangaroo(x1, v1, x2, v2);
            Console.WriteLine(result);
        }

        private static string kangaroo(int x1, int v1, int x2, int v2)
        {
            // they are already at same position
            if (x1 == x2)
                return "YES";
            // the difference between them will never decrease
            if ((x1 > x2 && v1 >= v2) || (x2 > x1 && v2 > v1) || v1 == v2)
            {
                return "NO";
            }
            while (x1 != x2)
            {
                var difference = x1 - x2;
                x1 += v1;
                x2 += v2;
                var newDifference = x1 - x2;
                // one has passed the other
                if (difference * newDifference < 0)
                    return "NO";
            }
            return "YES";
        }
    }
}
