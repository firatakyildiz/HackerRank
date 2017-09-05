using System;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list-in-reverse
    /// Difficulty : Easy
    /// </summary>
    public class PrintReverse
    {
        public static void ReversePrint(Node head)
        {
            // Since my code would be written inside the class in HackerRank editor,
            // I could not import System.Collections.Generic. So I used it inline.
            var stack = new System.Collections.Generic.Stack<int>();
            while (head != null) {
                stack.Push(head.Data);
                head = head.Next;
            }
            while (stack.Count != 0) {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
