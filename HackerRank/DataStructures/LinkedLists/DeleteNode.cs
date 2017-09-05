using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list
    /// Difficulty : Easy
    /// </summary>
    class DeleteNode
    {
        public static Node Delete(Node head, int position)
        {
            if (head == null)
                return null;
            if (position == 0)
                return head.Next;
            var current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next?.Next;
            return head;
        }
    }
}
