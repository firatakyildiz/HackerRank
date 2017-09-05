using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Note : C# was not available in HackerRank, so I wrote C++ instead.
    /// Link : https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
    /// Difficulty : Medium
    /// </summary>
    class CycleDetection
    {
        /*
            Detect a cycle in a linked list. Note that the head pointer may be 'NULL' if the list is empty.

            A Node is defined as: 
                struct Node {
                    int data;
                    struct Node* next;
                }
        */

        // This is a "method-only" submission.
        // You only need to complete this method.

        /// <summary>
        /// To detect a cycle in a linked list, we have to allocate two pointers from head.
        /// At each iteration, one pointer moves forward one step, the other moves two steps.
        /// If we reach the end of the list while iterating, there are no cycles.
        /// If at some point two pointers point to the same node, then there is a cycle in the list.
        /// </summary>

        //bool has_cycle(Node* head)
        //{
        //    if(head == null || head->next == null)
        //        return false;
        //    Node* first = head;
        //    Node* second = head;
        //    while (true)
        //    {
        //        if (first == NULL || second == NULL)
        //            return false;
        //        first = first->next;
        //        second = second->next->next;
        //        if (first == second)
        //            return true;
        //    }
        //}
    }
}
