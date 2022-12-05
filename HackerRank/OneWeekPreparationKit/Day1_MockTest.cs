using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit
{
    internal class Day1_MockTest
    {
        public static int findMedian(List<int> arr)
        {
            var array = arr.ToArray();
            Array.Sort(array);
            return array[array.Length / 2];
        }
    }
}
