using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
    /// Difficulty : Easy
    /// </summary>
    public class PrintElements
    {
        // This is a "method-only" submission.
        // You only need to complete this method.

        public static void Print(Node head)
        {
            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
        }
    }
}
