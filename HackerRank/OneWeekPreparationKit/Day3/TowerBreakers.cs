using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day3
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-tower-breakers-1/problem
    /// Difficulty : Easy
    /// Solution : See inline comments
    /// </summary>
    public static class TowerBreakers
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var numberOfTowers = int.Parse(input[0]);
                var towerHeight = int.Parse(input[1]);
                var result = 0;

                // if the tower height is 1, there are no moves to be made. Player 2 wins.
                if (towerHeight == 1)
                    result = 2;
                // if there are even number of towers, player 2 wins by mirroring every move made
                // by player 1. odd number of towers means player 1 wins by reducing one tower to 1,
                // then mirroring every move player 2 makes.
                else
                    result = numberOfTowers % 2 == 0 ? 2 : 1;
                Console.WriteLine(result);
            }
        }
    }
}
