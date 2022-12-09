using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day4
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-grid-challenge/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class GridChallenge
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var length = Convert.ToInt32(Console.ReadLine().Trim());
                var grid = new List<string>();

                for (var j = 0; j < length; j++)
                {
                    var gridItem = Console.ReadLine();
                    grid.Add(gridItem);
                }

                var result = gridChallenge(grid);
                Console.WriteLine(result);
            }
        }

        public static string gridChallenge(List<string> grid)
        {
            for (var i = 0; i < grid.Count; i++)
            {
                grid[i] = new string(grid[i].OrderBy(x => x).ToArray());
            }

            for (var i = 0; i < grid[0].Length; i++)
            {
                char c = 'a';
                for (int j = 0; j < grid.Count; j++)
                {
                    if (grid[j][i] < c)
                        return "NO";
                    c = grid[j][i];
                }
            }
            return "YES";
        }
    }
}
