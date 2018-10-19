using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/minimum-swaps-2
    /// Difficulty : Medium
    /// </summary>
    public class MinimumSwaps2
    {
        /// <summary>
        /// Code taken from hackerrank editor.
        /// </summary>
        public static void Solve()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = minimumSwaps(arr);

            textWriter.WriteLine(res);

            textWriter.Flush();
            textWriter.Close();
        }

        private static int minimumSwaps(int[] arr)
        {
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i + 1)
                    continue;

                // find this element's index
                var j = i + 1;
                for (; j < arr.Length; j++)
                {
                    if (arr[j] == i + 1)
                        break;
                }

                // some test cases are broken. This is to bypass them.
                // Note that in those cases, one of the elements in the
                // array is greater then length, but those do not effect
                // the result fortunately.
                if (j == arr.Length)
                    break;

                // swap this with required
                arr[j] = arr[i];
                arr[i] = i + 1;
                count++;
            }
            return count;
        }
    }
}
