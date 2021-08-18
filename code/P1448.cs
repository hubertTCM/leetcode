
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1448
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

    public class Solution
    {
        public int GoodNodes(TreeNode root)
        {
            return GoodNodes(root, root.val);
        }

        int GoodNodes(TreeNode node, int max)
        {
            if (node == null)
            {
                return 0;
            }
            var count = node.val >= max ? 1 : 0;
            var newMax = Math.Max(max, node.val);
            return count + GoodNodes(node.left, newMax) + GoodNodes(node.right, newMax);
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();

            Console.WriteLine(s.GoodNodes(Build("[3,1,4,3,null,1,5]")));//4
            Console.WriteLine(s.GoodNodes(Build("[3,3,null,4,2]")));//3
            Console.WriteLine(s.GoodNodes(Build("[2,null,4,10,8,null,null,4]"))); //4
        }

        static TreeNode Build(string s)
        {
            //[3,9,20,null,null,15,7]
            var source = s.Substring(1, s.Length - 2);
            Queue<string> items = new Queue<string>(source.Split(","));
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode root = null;
            while (items.Count > 0)
            {
                var item = items.Dequeue();
                if (root == null)
                {
                    root = new TreeNode();
                    root.val = int.Parse(item);
                    nodes.Enqueue(root);
                    continue;
                }
                TreeNode parent = nodes.Dequeue();
                if (string.Compare(item, "null", true) != 0)
                {
                    parent.left = new TreeNode(int.Parse(item));
                    nodes.Enqueue(parent.left);
                }
                if (items.Count > 0)
                {
                    item = items.Dequeue();
                    if (string.Compare(item, "null", true) != 0)
                    {
                        parent.right = new TreeNode(int.Parse(item));
                        nodes.Enqueue(parent.right);
                    }
                }
            }
            return root;
        }
    }
}
