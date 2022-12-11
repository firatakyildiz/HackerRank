using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-lego-blocks/problem
    /// Difficulty : Medium
    /// Solution : Instead of calculating all good wall combination counts, we can calculate all combination
    /// counts and then subtract bad combination counts.
    /// </summary>
    public static class LegoBlocks
    {
        public static int legoBlocks(int height, int width)
        {
            var modulo = (int)Math.Pow(10, 9) + 7;
            
            // precompute and store all combination counts for a single row
            var singleRowCombinationCounts = new long[width];
            for (var i = 0; i < width; i++)
            {
                if(i == 0)
                    singleRowCombinationCounts[0] = 1;
                else if(i == 1)
                    singleRowCombinationCounts[1] = 2;
                else if(i == 2)
                    singleRowCombinationCounts[2] = 4;
                else if (i == 3)
                    singleRowCombinationCounts[3] = 8;
                else
                    singleRowCombinationCounts[i] = (singleRowCombinationCounts[i - 1] 
                                        + singleRowCombinationCounts[i - 2]
                                        + singleRowCombinationCounts[i - 3]
                                        + singleRowCombinationCounts[i - 4]) % modulo;
            }

            // all possible (good or bad) combinations count of a n * x (1<=x<=m) wall
            var allPossibleCombinations = new long[width];
            for (var i = 0; i < width; i++)
            {
                var baseCount = singleRowCombinationCounts[i];
                var currentHeight = height;
                var result = baseCount;

                while (currentHeight > 1)
                {
                    result = (result * baseCount) % modulo;
                    currentHeight--;
                }

                allPossibleCombinations[i] = result;
            }

            // good combinations count of a n * x (1<=x<=m) wall
            var goodCombinationsCount = new long[width];
            goodCombinationsCount[0] = 1;
            for (var i = 0; i < width; i++)
            {
                var currentCombinationCount = allPossibleCombinations[i];
                for (var j = 0; j < i; j++)
                {
                    currentCombinationCount -= goodCombinationsCount[j] * allPossibleCombinations[i - j - 1] % modulo;
                }
                while (currentCombinationCount < 0)
                {
                    currentCombinationCount += modulo;
                }
                goodCombinationsCount[i] = currentCombinationCount;
            }
            return (int)(goodCombinationsCount[width - 1] % modulo);
        }

        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());

            for (var i= 0; i < numberOfTestCases; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(legoBlocks(input[0], input[1]));
            }
        }
    }
}
