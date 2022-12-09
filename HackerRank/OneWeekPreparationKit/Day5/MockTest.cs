using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day5
{
    /// <summary>
    /// Iterate over the input array, while keeping count of occurrences of each number.
    /// Whenever a new number is read, check if there are existing numbers which pair with this.
    /// </summary>
    internal class MockTest
    {
        public static int Solve(int k, List<int> arr)
        {
            // keep number of occurrences in the input array
            var dic = new Dictionary<int, int>();
            var count = 0;

            foreach (var currentNumber in arr)
            {
                if (dic.ContainsKey(currentNumber))
                    dic[currentNumber] += 1;
                else
                    dic[currentNumber] = 1;

                // check if there exists a lower number which pairs with this one
                if (currentNumber - k > 0)
                {
                    if (dic.ContainsKey(currentNumber - k))
                        count += dic[currentNumber - k];
                }

                // check if there exists a higher number which pairs with this one
                if(dic.ContainsKey(currentNumber + k))
                    count += dic[currentNumber + k];
            }
            return count;
        }
    }
}
