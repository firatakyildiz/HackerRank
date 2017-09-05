using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list
    /// Difficulty : Easy
    /// </summary>
    public class InsertNodeAtSpecificPosition
    {
        // This is a "method-only" submission.
        // You only need to complete this method.

        public static Node InsertNth(Node head, int data, int position)
        {
            var current = head;
            var newNode = new Node() { Data = data, Next = null };
            if (head == null)
                return newNode;
            if (position == 0) {
                newNode.Next = head;
                return newNode;
            }
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            return head;
        }
    }
}
