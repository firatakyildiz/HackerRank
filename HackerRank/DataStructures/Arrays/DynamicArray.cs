using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/dynamic-array
    /// Difficulty : Easy
    /// </summary>
    class DynamicArray
    {
        public static void Solve() {
            var temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var numberOfSequences = temp[0];
            var numberOfQueries = temp[1];
            var seqList = new List<List<int>>();
            var lastAnswer = 0;
            for (int i = 0; i < numberOfSequences; i++)
            {
                seqList.Add(new List<int>());
            }
            for (int i = 0; i < numberOfQueries; i++)
            {
                temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var queryType = temp[0];
                var sequenceIndex = temp[1];
                var value = temp[2];
                if (queryType == 1)
                {
                    var index = (sequenceIndex ^ lastAnswer) % numberOfSequences;
                    seqList[index].Add(value);
                }
                else // if(queryType == 2)
                {
                    var index = (sequenceIndex ^ lastAnswer) % numberOfSequences;
                    lastAnswer = seqList[index][value % seqList[index].Count];
                    Console.WriteLine(lastAnswer);
                }
            }
        }
    }
}
