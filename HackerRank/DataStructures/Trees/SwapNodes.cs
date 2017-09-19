using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Trees
{
    public static class SwapNodes
    {
        /// <summary>
        /// Link : https://www.hackerrank.com/challenges/swap-nodes-algo
        /// Difficulty : Medium
        /// </summary>
        public static void Solve() {
            // Since we have to keep track of all nodes in a list or array,
            // we can also use it for holding tree itself.
            var numberOfNodes = Convert.ToInt32(Console.ReadLine());
            var maxDepthOfTree = 1;
            nodeList = new Node[numberOfNodes + 1];
            for (int i = 1; i <= numberOfNodes; i++) {
                nodeList[i] = new Node { Id = i };
            }
            for (int i = 1; i <= numberOfNodes; i++)
            {
                // save children
                var children = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                nodeList[i].Left = children[0];
                nodeList[i].Right = children[1];
                // save parent
                if(nodeList[i].Left != -1)
                    nodeList[nodeList[i].Left].Parent = i;
                if (nodeList[i].Right != -1)
                    nodeList[nodeList[i].Right].Parent = i;
                // save depth
                if (i == 1)
                {
                    nodeList[i].Parent = -1;
                    nodeList[i].Depth = 1;
                }
                else {
                    nodeList[i].Depth = nodeList[nodeList[i].Parent].Depth + 1;
                    if (maxDepthOfTree < nodeList[i].Depth)
                        maxDepthOfTree = nodeList[i].Depth;
                }
            }
            var swapCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < swapCount; i++)
            {
                var swapDepth = Convert.ToInt32(Console.ReadLine());
                applyMultiSwaping(swapDepth, maxDepthOfTree);
                printInorder();
            }
        }

        // The multiple swap operations could have been done in one iteration of list,
        // but I misread the question and wrote this after swapAllChildren method.
        private static void applyMultiSwaping(int depth, int maxdepth) {
            var currentDepth = depth;
            while (currentDepth < maxdepth) {
                swapAllChildrenOfDepth(currentDepth);
                currentDepth += depth;
            }
        }

        /// <summary>
        /// Swapping indices is all we need to do for swapping subtrees.
        /// Iterate over the array and swap them all
        /// </summary>
        /// <param name="depth">The depth in which all subtrees will be swapped</param>
        private static void swapAllChildrenOfDepth(int depth) {
            for (int i = 1; i < nodeList.Length; i++)
            {
                if (nodeList[i].Depth == depth) {
                    var temp = nodeList[i].Left;
                    nodeList[i].Left = nodeList[i].Right;
                    nodeList[i].Right = temp;
                }
            }
        }
        
        private static void printInorder() {
            var stack = new Stack<int>();
            int current = 1;
            while (true) {
                if (current == -1 && stack.Count == 0)
                    break;
                else if (current != -1) {
                    stack.Push(current);
                    current = nodeList[current].Left;
                }
                else
                {
                    current = stack.Pop();
                    Console.Write(nodeList[current].Id + " ");
                    current = nodeList[current].Right;
                }
            }
            Console.WriteLine();
        }

        private static Node[] nodeList;

        private class Node
        {
            public int Id { get; set; }
            public int Depth { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
            public int Parent { get; set; }
        }
    }
}
