using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day4
{
    /// <summary>
    /// Use brute-force to check each petrol pump for being feasible.
    /// </summary>
    internal class MockTest
    {
        public static int truckTour(List<List<int>> petrolpumps)
        {
            // lets try bruteforce
            var index = 0;
            while (true)
            {
                var currentIndex = index;
                var currentFuelAmount = 0L;
                while (true)
                {
                    currentFuelAmount += petrolpumps[currentIndex][0] - petrolpumps[currentIndex][1];
                    if (currentFuelAmount < 0)
                        break;
                    currentIndex = (currentIndex + 1) % petrolpumps.Count;
                    if (currentIndex == index)
                        return index;
                }
                index = (index + 1) % petrolpumps.Count;
            }
        }
    }
}
