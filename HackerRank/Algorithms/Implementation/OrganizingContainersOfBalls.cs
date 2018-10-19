using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    public static class OrganizingContainersOfBalls
    {
        /// <summary>
        /// Link : https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem
        /// Difficulty : Medium
        /// </summary>
        public static void Solve() {
            var numberOfQueries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfQueries; i++)
            {
                var boxCount = Convert.ToInt32(Console.ReadLine());
                var matrix = new int[boxCount,boxCount];
                for (int j = 0; j < boxCount; j++)
                {
                    var rowValues = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    for (int k = 0; k < boxCount; k++)
                    {
                        matrix[j, k] = rowValues[k];
                    }
                }
                if(separationPossible(boxCount,matrix))
                    Console.WriteLine("Possible");
                else
                    Console.WriteLine("Impossible");
            }
        }

        /// <summary>
        /// Helper function determining if seperation of balls is possible.
        /// Since the box sizes never change with swap operations, all we
        /// need to check is whether initial box sizes are equal to 
        /// ball color counts.
        /// </summary>
        /// <param name="boxCount">Number of boxes</param>
        /// <param name="matrix">The matrix of distribution of balls</param>
        /// <returns></returns>
        private static bool separationPossible(int boxCount, int[,] matrix)
        {
            var initialBoxSizes = new int[boxCount];
            var colorCounts = new int[boxCount];
            for (int i = 0; i < boxCount; i++)
            {
                for (int j = 0; j < boxCount; j++)
                {
                    initialBoxSizes[i] += matrix[i, j];
                    colorCounts[j] += matrix[i, j];
                }
            }
            Array.Sort(initialBoxSizes);
            Array.Sort(colorCounts);
            return initialBoxSizes.SequenceEqual(colorCounts);
        }
    }
}
