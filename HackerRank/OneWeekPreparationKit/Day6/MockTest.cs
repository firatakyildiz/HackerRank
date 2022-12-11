using HackerRank.DataStructures.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    /// <summary>
    /// Use a queue for bfs, setting distances at each iteration.
    /// </summary>
    internal class MockTest
    {
        private class Node
        {
            public bool isVisited;
            public List<Node> children = new ();
            public int distanceToStart = -1;
        }

        public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {
            var list = new List<Node>();
            for (var i = 0; i < n; i++)
                list.Add(new Node());

            foreach (var edge in edges)
            {
                var firstNode = list[edge[0] - 1];
                var secondNode = list[edge[1] - 1];
                firstNode.children.Add(secondNode);
                secondNode.children.Add(firstNode);
            }

            var que = new Queue<Node>();
            var startNode = list[s - 1];
            startNode.distanceToStart = 0;
            que.Enqueue(startNode);
            while (que.Count > 0)
            {
                var current = que.Dequeue();
                foreach (var child in current.children)
                {
                    if (child.distanceToStart > -1)
                        continue;
                    child.distanceToStart = current.distanceToStart + 6;
                    que.Enqueue(child);
                }
            }

            return list.Where(x => x.distanceToStart != 0).Select(x => x.distanceToStart).ToList();
        }
    }
}
