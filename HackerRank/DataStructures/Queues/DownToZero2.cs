using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Queues
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/down-to-zero-ii/problem
    /// Difficulty : Medium
    /// Explanation : Precompute all possible values, starting from bottom (0) so that each value 
    /// computed is absolute minimum.
    /// </summary>
    class DownToZero2
    {
        public static void Solve()
        {
            // using DP, precompute all possible values
            const int maximumNumberOfElements = 1000001;
            var array = new int[maximumNumberOfElements];
            array[1] = 1;
            array[2] = 2;
            array[3] = 3;

            for (var i = 2; i < maximumNumberOfElements; i++)
            {
                // the cost may be equal to the cost of the item before it, plus one
                if (array[i] == 0 || array[i] > array[i - 1] + 1)
                    array[i] = array[i - 1] + 1;
                // the cost may be equal to some item multiplied by a number smaller than 
                // that item, plus one, whose value is already computed
                for (var j = 2; j <= i && i * j < maximumNumberOfElements; j++)
                {
                    if (array[i * j] == 0 || array[i] + 1 < array[i * j])
                        array[i * j] = array[i] + 1;
                }
            }

            var numberOfQueries = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfQueries; i++)
            {
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(array[input]);
            }
        }
    }
}
