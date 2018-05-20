using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Queues
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/queries-with-fixed-length/problem
    /// Difficulty : Hard
    /// Explanation : Finding maximum of all subarrays of size k, of a given array can be solved by using
    /// a double ended queue. A sliding window is kept with size k, new elements are added from back as long
    /// as they are greater than all of the elements to their left. So the queue is always in descending order
    /// with max residing in first
    /// </summary>
    public class QueriesWithFixedLength
    {
        public static void Solve()
        {
            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int[] queries = new int[q];

            for (int queriesItr = 0; queriesItr < q; queriesItr++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine());
                queries[queriesItr] = queriesItem;
            }

            int[] result = solve(arr, queries);

            Console.WriteLine(string.Join("\n", result));
        }

        private static int[] solve(int[] arr, int[] queries)
        {
            var len = queries.Length;
            var returnArray = new int[len];
            for (var i = 0; i < len; i++)
            {
                returnArray[i] = GetMaxes(arr, queries[i]).Min();
            }
            return returnArray;
        }

        private static int[] GetMaxes(int[] arr, int size)
        {
            var arrayOfMaxes = new int[arr.Length - size + 1];
            var maxIndex = 0;
            var list = new LinkedList<int>();
            // prepare sliding window
            int i = 0;
            for (i = 0; i < size; i++)
            {
                while(list.Any() && arr[i] >= arr[list.Last.Value])
                    list.RemoveLast();
                list.AddLast(i);
            }

            for (; i < arr.Length; i++)
            {
                // the first element in the queue is max of previous window
                var first = list.First.Value;
                arrayOfMaxes[maxIndex++] = arr[first];
                // check if first element is now out of window
                if(first <= i - size)
                    list.RemoveFirst();

                // reconstruct the queue
                while(list.Any() && arr[i] >= arr[list.Last.Value])
                    list.RemoveLast();
                list.AddLast(i);
            }
            arrayOfMaxes[maxIndex] = arr[list.First.Value];
            return arrayOfMaxes;
        }
    }
}
