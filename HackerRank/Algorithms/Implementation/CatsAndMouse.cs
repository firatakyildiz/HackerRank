using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/cats-and-a-mouse/problem
    /// Difficulty : Easy
    /// </summary>
    public static class CatsAndMouse
    {
        public static void Solve()
        {
            var len = int.Parse(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var distanceFirst = Math.Abs(arr[0] - arr[2]);
                var distanceSecond = Math.Abs(arr[1] - arr[2]);
                if(distanceSecond == distanceFirst)
                    Console.WriteLine("Mouse C");
                else if(distanceSecond > distanceFirst)
                    Console.WriteLine("Cat A");
                else
                    Console.WriteLine("Cat B");
            }
        }
    }
}
