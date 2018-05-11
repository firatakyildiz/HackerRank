using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    class GameOfTwoStacks
    {
        /// <summary>
        /// Link : https://www.hackerrank.com/challenges/game-of-two-stacks/problem
        /// Difficulty : Medium
        /// </summary>
        public static void Solve()
        {
            int g = Convert.ToInt32(Console.ReadLine());

            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] nmx = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmx[0]);

                int m = Convert.ToInt32(nmx[1]);

                int x = Convert.ToInt32(nmx[2]);

                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
                int result = twoStacks(x, a, b);

                Console.WriteLine(result);
            }
        }

        static int twoStacks(int x, int[] a, int[] b)
        {
            long total = 0;
            int maxCount = 0, count = 0, index = 0, secondIndex = 0;

            // select each element from first array
            while (index < a.Length && total + a[index] <= x )
            {
                total += a[index++];
            }
            count = index;
            maxCount = count;
            index--;
            // remove one element from first array, select as many elements as possible from second array
            // check all possibilities until all elements are chosen from second array
            while (secondIndex < b.Length)
            {
                if (b[secondIndex] + total <= x)
                {
                    total += b[secondIndex++];
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                else
                {
                    if (index < 0) break;
                    total -= a[index--];
                    count--;
                }
            }
            return maxCount;
        }
    }
}
