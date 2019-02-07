using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.BalancedTrees
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/self-balancing-tree/problem
    /// Difficulty : Medium
    /// Note : C# was not available, below code is written to (mostly) compile with Java 
    /// </summary>
    class SelfBalancingTree
    {
        private class Node
        {
            public int val; //Value
            public int ht; //Height
            public Node left; //Left child
            public Node right; //Right child
        }

        static Node insert(Node root, int val)
        {
            if (root == null)
            {
                root = new Node();
                root.val = val;
                root.ht = setHeight(root);
                return root;
            }
            if (val <= root.val)
            {
                root.left = insert(root.left, val);
            }
            else if (val > root.val)
            {
                root.right = insert(root.right, val);
            }
            int balance = getHeight(root.left) - getHeight(root.right);

            if (balance > 1)
            {
                if (getHeight(root.left.left) >= getHeight(root.left.right))
                {
                    root = rotateRight(root);
                }
                else
                {
                    root.left = rotateLeft(root.left);
                    root = rotateRight(root);
                }
            }
            else if (balance < -1)
            {
                if (getHeight(root.right.right) >= getHeight(root.right.left))
                {
                    root = rotateLeft(root);
                }
                else
                {
                    root.right = rotateRight(root.right);
                    root = rotateLeft(root);
                }
            }
            else
            {
                root.ht = setHeight(root);
            }
            return root;
        }

        private static Node rotateRight(Node root)
        {
            Node node = root.left;
            root.left = node.right;
            node.right = root;
            root.ht = setHeight(root);
            node.ht = setHeight(node);
            return node;
        }

        private static Node rotateLeft(Node root)
        {
            Node node = root.right;
            root.right = node.left;
            node.left = root;
            root.ht = setHeight(root);
            node.ht = setHeight(node);
            return node;
        }

        private static int getHeight(Node node)
        {
            return node == null ? -1 : node.ht;
        }

        private static int setHeight(Node node)
        {
            // change to Math.max for java
            return node == null ? -1 : 1 + Math.Max(getHeight(node.left), getHeight(node.right)); 
        }
    }
}
