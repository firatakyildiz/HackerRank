using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/flatland-space-stations/problem
    /// Difficulty : Easy
    /// Solution : There are 3 cases to consider. The first case is for cities between stations.
    /// A candidate city with max distance is the one that is at exact middle of both stations.
    /// It does not matter if the distance is an odd integer. The other cases are the first and
    /// last cities.
    /// </summary>
    public static class FlatlandSpaceStations
    {
        public static void Solve()
        {
            var numberOfCities = int.Parse(Console.ReadLine().Split()[0]);
            var spaceStations = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var maximumDistance = 0;
            Array.Sort(spaceStations);

            for (int i = 0; i < spaceStations.Length - 1; i++)
            {
                var distance = (spaceStations[i + 1] - spaceStations[i]) / 2;
                if (distance > maximumDistance)
                    maximumDistance = distance;
            }

            maximumDistance = Math.Max(maximumDistance, spaceStations[0]);
            if(numberOfCities > 1)
                maximumDistance = Math.Max(maximumDistance, numberOfCities - 1 - spaceStations[spaceStations.Length - 1]);

            Console.WriteLine(maximumDistance);
        }
    }
}
