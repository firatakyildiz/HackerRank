using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
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
                //// lets try naive way
                //for (int i = a; i <= b; i++)
                //{
                //    arr[i - 1] += k;
                //}
                //// ofc it failed,lets try something more efficient
                arr[a - 1] += k;
                arr[b - 1] -= k;
            }
            // now the problem is reduced to max subsequence.this is solved in O(n)
            long globalMaximum = 0;
            long localMaximum = 0;
            for (int i = 0; i < n; i++)
            {
                localMaximum += arr[i];
                if (globalMaximum < localMaximum)
                    globalMaximum = localMaximum;
                if (localMaximum < 0)
                    localMaximum = 0;
            }
            Console.WriteLine(globalMaximum);
        }
    }
}
