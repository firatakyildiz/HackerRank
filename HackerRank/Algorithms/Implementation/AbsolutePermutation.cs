using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/absolute-permutation/problem
    /// Difficulty : Medium
    /// Solution : From extensive mathematical induction, it can be seen that there is only one absolute permutation for any given n and k values.
    /// It exists only when n % 2*k == 0, and it is of the form => (k + 1)...(2k),(1)...(k),(3k+1)...(4k),(2k+1)...(3k)...
    /// This solution computes that array from given n and k values. 
    /// </summary>
    public static class AbsolutePermutation
    {
        public static void Solve()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nk = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(nk[0]);
                int k = Convert.ToInt32(nk[1]);
                int[] result = absolutePermutation(n, k);
                Console.WriteLine(string.Join(" ", result));
            }
        }

        private static int[] absolutePermutation(int numberOfElements, int absoluteDifference)
        {
            if (absoluteDifference == 0)
                return Enumerable.Range(1, numberOfElements).ToArray();
            if (numberOfElements % (2 * absoluteDifference) != 0)
                return new[] {-1};
            
            var arr = new int[numberOfElements];
            for (int index = 0, cycleIndex = 0;index < numberOfElements;cycleIndex += 2)
            {
                for (var j = 0; j < absoluteDifference; j++)
                {
                    arr[index++] = absoluteDifference * (cycleIndex + 1) + j + 1;
                }
                for (var j = 0; j < absoluteDifference; j++)
                {
                    arr[index++] = absoluteDifference * cycleIndex + j + 1;
                }
            }
            return arr;
        }
    }
}
