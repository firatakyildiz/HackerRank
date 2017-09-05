using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Note : C# was not available in HackerRank, so I wrote C++ instead.
    /// Link : https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists
    /// Difficulty : Easy
    /// </summary>
    class MergeTwoSortedLinkedLists
    {
        //Node* MergeLists(Node* headA, Node* headB)
        //{
        //    Node* head;
        //    if (headA == NULL)
        //        return headB;
        //    if (headB == NULL)
        //        return headA;
        //    if (headA->data < headB->data)
        //    {
        //        head = headA;
        //        headA = headA->next;
        //    }
        //    else
        //    {
        //        head = headB;
        //        headB = headB->next;
        //    }
        //    Node* current = head;
        //    while (headA != NULL && headB != NULL)
        //    {
        //        if (headA->data < headB->data)
        //        {
        //            current->next = headA;
        //            current = current->next;
        //            headA = headA->next;
        //        }
        //        else
        //        {
        //            current->next = headB;
        //            current = current->next;
        //            headB = headB->next;
        //        }
        //    }
        //    if (headA == NULL)
        //        current->next = headB;
        //    else
        //        current->next = headA;
        //    return head;
        //}
    }
}
