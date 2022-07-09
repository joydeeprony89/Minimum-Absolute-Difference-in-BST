using System;
using System.Collections.Generic;

namespace Minimum_Absolute_Difference_in_BST
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(543);
      root.left = new TreeNode(384);
      root.right = new TreeNode(652);
      root.right.right = new TreeNode(699);

      root.left.right = new TreeNode(445);

      Solution s = new Solution();
      s.GetMinimumDifference(root);
    }
  }

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

  public class Solution
  {
    public int GetMinimumDifference(TreeNode root)
    {
      // As the tree is BST, if we take teh inorder, will get the values in sorted order
      // then O(n) pass we can traverse the entire array and get the min difference
      List<int> list = new List<int>();
      InOrder(root, list);
      int i = 1;
      int min = int.MaxValue;
      while (i < list.Count)
      {
        min = Math.Min(min, Math.Abs(list[i] - list[i - 1]));
        i++;
      }

      return min;
    }

    private void InOrder(TreeNode root, List<int> list)
    {
      if (root == null) return;

      InOrder(root.left, list);
      list.Add(root.val);
      InOrder(root.right, list);
    }
  }
}
