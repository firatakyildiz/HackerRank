using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/happy-ladybugs/problem
    /// Difficulty : Easy
    /// </summary>
    public static class HappyLadybugs
    {
        public static void Solve()
        {
            var numberOfGames = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfGames; i++)
            {
                var len = Console.ReadLine();
                var board = Console.ReadLine();
                var result = CanAllBugsBeHappy(board);
                Console.WriteLine(result ? "YES" : "NO");
            }
        }

        private static bool CanAllBugsBeHappy(string board)
        {
            // maybe they are already happy?
            var alreadyHappy = true;
            // we need at least one empty space to be able to swap bugs
            var emptySpacePresent = false;
            // each ladybug must have at least one of its kind to be happy
            var map = new Dictionary<char, int>();

            for (var i = 0; i < board.Length; i++)
            {
                if (board[i] == '_')
                {
                    emptySpacePresent = true;
                    continue;
                }

                if (!map.ContainsKey(board[i]))
                    map[board[i]] = 1;
                else
                    map[board[i]] = map[board[i]] + 1;

                if (alreadyHappy)
                {
                    var hasFriendBefore = i != 0 && board[i - 1] == board[i];
                    var hasFriendAfter = i != board.Length - 1 && board[i + 1] == board[i];
                    if (!hasFriendAfter && !hasFriendBefore)
                        alreadyHappy = false;
                }
            }

            if (alreadyHappy)
                return true;

            if (!emptySpacePresent)
                return false;

            foreach (var bugKind in map.Keys)
            {
                if (map[bugKind] == 1)
                    return false;
            }

            return true;
        }
    }
}
