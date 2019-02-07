using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
    /// Difficulty : Medium
    /// </summary>
    public static class ClimbingTheLeaderboard
    {
        public static void Solve()
        {
            int scoresCount = Convert.ToInt32(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int aliceCount = Convert.ToInt32(Console.ReadLine());
            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
            int[] result = climbingLeaderboard(scores, alice);
            Console.WriteLine(string.Join("\n", result));
        }

        private static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var list = new List<int>() {scores[0]};
            var positions = new List<int>();
            // create the leaderboard
            for (var i = 1; i < scores.Length; i++)
            {
                var currentScore = scores[i];
                if(currentScore != list[list.Count - 1])
                    list.Add(currentScore);
            }

            // calculate Alice's position for each of her score
            var currentPosition = list.Count + 1;
            var listIndex = list.Count - 1;
            foreach (var score in alice)
            {
                while (listIndex != -1 && score >= list[listIndex])
                {
                    listIndex--;
                    currentPosition--;
                }
                positions.Add(currentPosition);
            }
            return positions.ToArray();
        }
    }
}
