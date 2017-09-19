using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Trees
{
    /// <summary>
    /// Note : C# was not available in HackerRank, so I wrote C++ instead.
    /// Link : https://www.hackerrank.com/challenges/is-binary-search-tree
    /// Difficulty : Medium
    /// </summary>
    class IsThisBinarySearchTree
    {
        //bool checkBST(Node* root)
        //{
        //    return checkBstHelper(root, 0, 10000);
        //}
        //bool checkBstHelper(Node* root, int min, int max)
        //{
        //    if (!root) return true;
        //    if (root->data > max || root->data < min)
        //        return false;
        //    int leftMin = min;
        //    int leftMax = max < root->data - 1 ? max : root->data - 1;
        //    int rightMin = min > root->data + 1 ? min : root->data + 1;
        //    int rightMax = max;
        //    return checkBstHelper(root->left, leftMin, leftMax) && checkBstHelper(root->right, rightMin, rightMax);
        //}
    }
}
