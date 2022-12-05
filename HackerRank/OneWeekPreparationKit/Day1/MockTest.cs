using System;
using System.Collections.Generic;

namespace HackerRank.OneWeekPreparationKit.Day1
{
    internal class MockTest
    {
        public static int findMedian(List<int> arr)
        {
            var array = arr.ToArray();
            Array.Sort(array);
            return array[array.Length / 2];
        }
    }
}
