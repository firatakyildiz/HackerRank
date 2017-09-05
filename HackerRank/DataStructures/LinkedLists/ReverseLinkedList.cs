using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Note : C# was not present in HackerRank editor.
    /// Link : https://www.hackerrank.com/challenges/reverse-a-linked-list
    /// Difficulty : Easy 
    /// </summary>
    class ReverseLinkedList
    {
        // Here is a Java implementation which uses a stack

        //Node Reverse(Node head)
        //{
        //    java.util.Stack<Node> stack = new Stack<Node>();
        //    while (head != null)
        //    {
        //        stack.add(head);
        //        head = head.next;
        //    }
        //    if (stack.empty())
        //        return null;
        //    head = stack.pop();
        //    Node current = head;
        //    while (!stack.empty())
        //    {
        //        current.next = stack.pop();
        //        current = current.next;
        //    }
        //    current.next = null;
        //    return head;
        //}



        // Here is a C++ implementation which does not use any extra space
        // (Uses constant space, without regarding input size)

        //Node* Reverse(Node* head)
        //{
        //    if (head == NULL)
        //        return head;
        //    Node* first = head;
        //    Node* second = head->next;
        //    first->next = NULL;
        //    while (second != NULL)
        //    {
        //        Node* temp = second->next;
        //        second->next = first;
        //        first = second;
        //        second = temp;
        //    }
        //    return first;
        //}
    }
}
