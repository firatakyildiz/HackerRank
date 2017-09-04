using System;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/crush
    /// Difficulty : Hard
    /// </summary>
    public class ArrayManipulation
    {
        public static void Solve() {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            var arr = new long[n];
            for (int a0 = 0; a0 < m; a0++)
            {
                string[] tokens_a = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(tokens_a[0]);
                int b = Convert.ToInt32(tokens_a[1]);
                int k = Convert.ToInt32(tokens_a[2]);
                // instead of calculating each element in the array,
                // lets just keep differences from a previous element
                arr[a - 1] += k; // this element is k more than its previous
                // this element is k less than its previous
                // if we are end of the list, do not try to update anything
                if (b != n) 
                    arr[b] -= k;
            }
            // now the problem is reduced to max continuous subsequence.this is solved in O(n)
            long globalMaximum = 0;
            long localMaximum = 0;
            for (int i = 0; i < n; i++)
            {
                localMaximum += arr[i];
                if (globalMaximum < localMaximum)
                    globalMaximum = localMaximum;
            }
            Console.WriteLine(globalMaximum);
        }
    }
}
