using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HackerRank.DataStructures.Advanced
{
    public static class MrXAndHisShots
    {
        /// <summary>
        /// Link : https://www.hackerrank.com/challenges/x-and-his-shots/problem
        /// Difficulty : Medium
        /// Solution : Instead of finding overlapping shots, it is far easier to
        /// find non-overlapping shots and remove the count from total shots.
        /// Non-overlapping shots are either those started after a shot's end,
        /// or those ended before a shot's start.
        /// </summary>
        public static void Solve()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            int[][] shots = new int[n][];
            for (int shotsRowItr = 0; shotsRowItr < n; shotsRowItr++)
            {
                shots[shotsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), shotsTemp => Convert.ToInt32(shotsTemp));
            }
            int[][] players = new int[m][];
            for (int playersRowItr = 0; playersRowItr < m; playersRowItr++)
            {
                players[playersRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), playersTemp => Convert.ToInt32(playersTemp));
            }
            int result = solve(shots, players);
            Console.WriteLine(result);
        }

        private static int solve(int[][] shots, int[][] players)
        {
            var shotStarts = new List<int>();
            var shotEnds = new List<int>();
            foreach (var shot in shots)
            {
                shotStarts.Add(shot[0]);
                shotEnds.Add(shot[1]);
            }

            shotStarts.Sort();
            shotEnds.Sort();

            var sumOfStrengths = 0;
            var len = shots.Length;
            foreach (var player in players)
            {
                var beginValue = player[0];
                var endValue = player[1];

                var missedAfterShotCount = modifiedBinarySearch(shotStarts, endValue, true);
                var missedBeforeShotCount = modifiedBinarySearch(shotEnds, beginValue, false);

                var strength = len - missedBeforeShotCount - missedAfterShotCount;
                sumOfStrengths += strength;
            }
            return sumOfStrengths;
        }

        /// <summary>
        /// This will return number of entries that are either greater or
        /// smaller than given value.
        /// </summary>
        /// <param name="direction">false returns smaller element count,
        /// true returns bigger element count</param>
        private static int modifiedBinarySearch(List<int> list, int value, bool direction)
        {
            var begin = 0;
            var end = list.Count - 1;
            var mid = 0;
            if (value < list[begin])
                return direction ? list.Count : 0;
            if (value > list[end])
                return direction ? 0 : list.Count;

            while (begin <= end)
            {
                mid = (end - begin) / 2 + begin;
                if (list[mid] == value)
                {
                    var newIndex = skipDuplicates(list, mid, direction);
                    if (direction)
                        return list.Count - newIndex - 1;
                    else
                    {
                        return newIndex;
                    }
                }
                else if (value > list[mid])
                {
                    begin = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            // element does not exist
            if (mid == begin && direction)
            {
                return list.Count - mid;
            }
            else if (mid == end && direction)
            {
                return list.Count - mid - 1;
            }
            else if (mid == begin && !direction)
            {
                return mid;
            }
            // else if(mid == end && !direction)
            return mid + 1;
        }

        /// <summary>
        /// Since binary search does not consider duplicates, this will perform an
        /// iterative search for duplicates.
        /// </summary>
        private static int skipDuplicates(List<int> list, int index, bool direction)
        {
            var iterator = direction ? 1 : -1;
            var originalValue = list[index];
            while (true)
            {
                var newIndex = index + iterator;
                if (newIndex < 0 || newIndex == list.Count)
                    break;
                if (list[newIndex] != originalValue)
                    break;
                index = newIndex;
            }
            return index;
        }
    }
}
