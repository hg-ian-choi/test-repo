using System;
using System.Collections.Generic;

public class BalancedBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public bool IsBalanced(TreeNode root)
    {
        if (root != null)
        {
            if (Math.Abs(getDepth(root.left) - getDepth(root.right)) > 1)
            {
                return false;
            }
            if (!IsBalanced(root.right) || !IsBalanced(root.left))
            {
                return false;
            }
        }

        return true;
    }

    public int getDepth(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        return Math.Max(getDepth(node.left), getDepth(node.right)) + 1;
    }


    // Best Solution
    // Best Solution 1:
    public bool bestSolution1(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }
        if (Math.Abs(bestSolution1_height(root.left) - bestSolution1_height(root.right)) <= 1)
        {
            return true && bestSolution1(root.left) && bestSolution1(root.right);
        }
        else
        {
            return false;
        }
    }

    public int bestSolution1_height(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        return 1 + Math.Max(bestSolution1_height(node.left), bestSolution1_height(node.right));
    }

    // Best Solution 2: Recursion (DFS post-order traversal)
    public bool bestSolution2(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        List<int> diffs = new List<int>();
        bestSolution2_isBalancedInternal(root, diffs);
        return diffs.Count == 0;
    }

    private int bestSolution2_isBalancedInternal(TreeNode node, List<int> diffs)
    {
        if (node == null)
        {
            return 0;
        }

        int heightLeft = bestSolution2_isBalancedInternal(node.left, diffs);
        int heightRight = bestSolution2_isBalancedInternal(node.right, diffs);

        int diff = Math.Abs(heightLeft - heightRight);
        if (diff > 1)
        {
            diffs.Add(diff);
        }

        return Math.Max(heightLeft, heightRight) + 1;
    }
}
