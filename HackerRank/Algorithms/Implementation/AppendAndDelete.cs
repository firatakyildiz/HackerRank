using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/append-and-delete/problem
    /// Difficulty : Easy
    /// </summary>
    public static class AppendAndDelete
    {
        public static void Solve()
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();
            var moves = int.Parse(Console.ReadLine());

            // we have enough moves to completely rewrite one string
            if (moves >= first.Length + second.Length)
            {
                Console.WriteLine("Yes");
                return;
            }

            var matchingPrefixSize = 0;
            while (true)
            {
                if (matchingPrefixSize >= first.Length || matchingPrefixSize >= second.Length)
                    break;
                if (first[matchingPrefixSize] != second[matchingPrefixSize])
                    break;
                matchingPrefixSize++;
            }

            // first, remove small string's extra characters
            var requiredMoves = Math.Min(first.Length, second.Length) - matchingPrefixSize;
            // then add big string's extra characters
            requiredMoves += Math.Max(first.Length, second.Length) - matchingPrefixSize;

            // not enough moves
            if (moves < requiredMoves)
            {
                Console.WriteLine("No");
                return;
            }

            // we get some extra moves that we can not get rid of
            if ((moves - requiredMoves) % 2 == 1)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
        }
    }
}
