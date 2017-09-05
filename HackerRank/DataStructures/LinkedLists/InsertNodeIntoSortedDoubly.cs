using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.LinkedLists
{
    /// <summary>
    /// Note : C# was not available in HackerRank, so I wrote C++ instead.
    /// Link : https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list
    /// Difficulty : Easy
    /// </summary>
    class InsertNodeIntoSortedDoubly
    {
        //Node* SortedInsert(Node* head, int data)
        //{
        //    Node* newNode = new Node();
        //    newNode->data = data;
        //    if (head == NULL)
        //    {
        //        newNode->next = NULL;
        //        newNode->prev = NULL;
        //        return newNode;
        //    }
        //    Node* current = head;
        //    while (data > current->data && current->next != NULL)
        //    {
        //        current = current->next;
        //    }
        //    if (data < current->data)
        //    {
        //        newNode->next = current;
        //        newNode->prev = current->prev;
        //        if (current->prev)
        //            current->prev->next = newNode;
        //        current->prev = newNode;
        //    }
        //    else
        //    {
        //        newNode->next = current->next;
        //        newNode->prev = current;
        //        current->next = newNode;
        //    }
        //    while (head->prev != NULL)
        //        head = head->prev;
        //    return head;
        //}
    }
}
