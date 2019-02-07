using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.DisjointSet
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/components-in-graph/problem
    /// Difficulty : Medium
    /// Note : Sample code is wrong. "SPACE" should be replaced with "result".
    /// Solution : Pretty straightforward. Keep the graph in memory and traverse
    /// each node and count.
    /// </summary>
    public static class ComponentsInAGraph
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] gb = new int[n][];
            for (int gbRowItr = 0; gbRowItr < n; gbRowItr++)
            {
                gb[gbRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), gbTemp => Convert.ToInt32(gbTemp));
            }
            int[] result = componentsInGraph(gb);
            Console.WriteLine(string.Join(" ", result));
        }

        private class Node
        {
            public Node()
            {
                NeighborIndices = new List<int>();
            }
            public bool IsVisited { get; set; }
            public List<int> NeighborIndices { get; set; }
        }

        private static int[] componentsInGraph(int[][] gb)
        {
            var len = gb.Length;
            var graph = new Node[len * 2];
            var que = new Queue<int>();
            var smallestSubgraphSize = int.MaxValue;
            var biggestSubgraphSize = int.MinValue;

            // create an empty graph with at most 2 * N nodes
            for (int i = 0; i < len * 2; i++)
            {
                graph[i] = new Node();
            }

            // initialize edges
            for (int i = 0; i < len; i++)
            {
                graph[gb[i][0] - 1].NeighborIndices.Add(gb[i][1] - 1);
                graph[gb[i][1] - 1].NeighborIndices.Add(gb[i][0] - 1);
            }

            // traverse graph starting at each node
            for (int i = 0; i < len * 2; i++)
            {
                if(graph[i].IsVisited) continue;
                var currentSubgraphSize = 0;
                que.Clear();
                que.Enqueue(i);
                while (que.Any())
                {
                    var currentNodeIndex = que.Dequeue();
                    if (graph[currentNodeIndex].IsVisited) continue;
                    graph[currentNodeIndex].IsVisited = true;
                    currentSubgraphSize++;
                    foreach (var neighborIndex in graph[currentNodeIndex].NeighborIndices)
                    {
                        que.Enqueue(neighborIndex);
                    }
                }

                if (currentSubgraphSize == 1) continue;
                if (currentSubgraphSize > biggestSubgraphSize)
                    biggestSubgraphSize = currentSubgraphSize;
                if (currentSubgraphSize < smallestSubgraphSize)
                    smallestSubgraphSize = currentSubgraphSize;
            }
            return new[] {smallestSubgraphSize, biggestSubgraphSize};
        }
    }
}
