using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Queues
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/castle-on-the-grid/problem
    /// Difficulty : Medium
    /// Note : The main method given in the problem does not work.
    /// </summary>
    public class CastleOnTheGrid
    {
        class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsVisited { get; set; }
            public int Cost { get; set; }
            public bool IsPassable { get; set; }
        }

        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            var len = grid.Length;
            var map = new Node[len ,len];
            var que = new Queue<Node>();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    map[i,j] = new Node()
                    {
                        X = i,
                        Y = j,
                        IsPassable = grid[i][j] == '.'
                    };
                }
            }
            var startNode = map[startX, startY];
            startNode.IsVisited = true;
            startNode.Cost = 0;
            que.Enqueue(startNode);
            while (que.Any())
            {
                var node = que.Dequeue();
                var cost = node.Cost;
                var x = node.X;
                var y = node.Y;

                // go down
                x++;
                while (x < len)
                {
                    if (!map[x, y].IsPassable)
                        break;
                    if (map[x, y].IsVisited && map[x, y].Cost <= cost + 1)
                    {
                        x++;
                        continue;
                    }
                    map[x, y].Cost = cost + 1;
                    map[x, y].IsVisited = true;
                    que.Enqueue(map[x,y]);
                    x++;
                }
                

                // go up
                x = node.X - 1;
                while (x > -1)
                {
                    if(!map[x,y].IsPassable)
                        break;
                    if (map[x, y].IsVisited && map[x, y].Cost <= cost + 1)
                    {
                        x--;
                        continue;
                    }
                    map[x, y].Cost = cost + 1;
                    map[x, y].IsVisited = true;
                    que.Enqueue(map[x, y]);
                    x--;
                }
                

                //go right
                x = node.X;
                y++;
                while (y < len)
                {
                    if (!map[x, y].IsPassable)
                        break;
                    if (map[x, y].IsVisited && map[x, y].Cost <= cost + 1)
                    {
                        y++;
                        continue;
                    }
                    map[x, y].Cost = cost + 1;
                    map[x, y].IsVisited = true;
                    que.Enqueue(map[x, y]);
                    y++;
                }
                

                //go left
                y = node.Y - 1;
                while (y > -1)
                {
                    if (!map[x, y].IsPassable)
                        break;
                    if (map[x, y].IsVisited && map[x, y].Cost <= cost + 1)
                    {
                        y--;
                        continue;
                    }
                    map[x, y].Cost = cost + 1;
                    map[x, y].IsVisited = true;
                    que.Enqueue(map[x, y]);
                    y--;
                }
            }
            return map[goalX, goalY].Cost;
        }

        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var grid = new string[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }
            string[] startXStartY = Console.ReadLine().Split(' ');

            int startX = Convert.ToInt32(startXStartY[0]);

            int startY = Convert.ToInt32(startXStartY[1]);

            int goalX = Convert.ToInt32(startXStartY[2]);

            int goalY = Convert.ToInt32(startXStartY[3]);

            int result = minimumMoves(grid, startX, startY, goalX, goalY);

            Console.WriteLine(result);
        }
    }
}
