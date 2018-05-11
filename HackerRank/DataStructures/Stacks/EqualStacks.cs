using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/equal-stacks/problem
    /// Difficulty : Easy
    /// </summary>
    class EqualStacks
    {
        static int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            int total1 = h1.Sum(), total2 = h2.Sum(), total3 = h3.Sum();
            int index1 = 0, index2 = 0, index3 = 0;
            while(!(total1 == total2 && total2 == total3))
            {
                while (total1 > total2 && total1 > 0)
                {
                    total1 -= h1[index1++];
                }

                while (total2 > total3 && total2 > 0)
                {
                    total2 -= h2[index2++];
                }

                while (total3 > total1 && total3 > 0)
                {
                    total3 -= h3[index3++];
                }
            }
            return total1;
        }

        public static void Solve()
        {
            string[] n1N2N3 = Console.ReadLine().Split(' ');

            int n1 = Convert.ToInt32(n1N2N3[0]);

            int n2 = Convert.ToInt32(n1N2N3[1]);

            int n3 = Convert.ToInt32(n1N2N3[2]);

            int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp));

            int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp));

            int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp));
            int result = equalStacks(h1, h2, h3);

            Console.WriteLine(result);
        }
    }
}
