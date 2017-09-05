using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list
    /// Difficulty : Easy
    /// </summary>
    public class InsertTailNode
    {
        // This is a "method-only" submission.
        // You only need to complete this method.

        public static Node Insert(Node head, int x)
        {
            var newNode = new Node() { Data = x, Next = null };
            if (head == null)
                return newNode;
            var current = head;
            while (current.Next != null) {
                current = current.Next;
            }
            current.Next = newNode;
            return head;
        }
    }
}
