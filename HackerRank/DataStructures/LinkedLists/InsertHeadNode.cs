using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/insert-a-node-at-the-head-of-a-linked-list
    /// Difficulty : Easy
    /// </summary>
    public class InsertHeadNode
    {
        // This is a "method-only" submission.
        // You only need to complete this method.

        public static Node Insert(Node head, int x)
        {
            return new Node() { Data = x, Next = head };
        }
    }
}
