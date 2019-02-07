using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited/problem
    /// Difficulty : Easy
    /// Solution : Although test case 1 is wrong, you can ignore it since you get full
    /// score while failing it. 
    /// </summary>
    public static class JumpingCloudsRevisited
    {
        public static void Solve()
        {
            var distance = int.Parse(Console.ReadLine().Split()[1]);
            var clouds = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var location = 0;
            var energy = 100;
            while (true)
            {
                location = (location + distance) % clouds.Length;
                energy--;
                if (clouds[location] == 1)
                    energy -= 2;
                if (location == 0)
                    break;
            }

            Console.WriteLine(energy);
        }
    }
}
