using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    internal class CountTriplets
    {
        public static long countTriplets(List<long> arr, long r)
        {
            var singles = new Dictionary<long, long>();
            var doubles = new Dictionary<long, long>();
            var tripletsCount = 0L;
            foreach (var number in arr)
            {
                var candidate = number / r;

                // if the result of the division is not an integer, disregard it
                if (candidate * r == number)
                {
                    // this means we have found triplets
                    if (doubles.ContainsKey(candidate))
                        tripletsCount += doubles[candidate];

                    // whenever a new element is read from the array, if we had read a number that is r times this one,
                    // keep track of this too, in another hashmap
                    if (singles.ContainsKey(candidate))
                    {
                        if (doubles.ContainsKey(number))
                            doubles[number] += singles[candidate];
                        else
                            doubles[number] = singles[candidate];
                    }
                }

                // put each element into the hashmap, this keeps count of base(first of triplets) elements
                if (singles.ContainsKey(number))
                    singles[number]++;
                else
                    singles[number] = 1;
            }
            return tripletsCount;
        }
    }
}