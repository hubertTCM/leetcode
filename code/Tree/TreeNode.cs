using System.Collections.Generic;
using System.Text;
namespace Tree
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

    public static class TreeHelper
    {
        public static TreeNode Build(string s)
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

        public static string Display(this TreeNode root)
        {
            var ans = new StringBuilder();
            ans.Append("[");
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            var first = true;
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                if (!first)
                {
                    ans.Append(", ");
                }

                if (node != null)
                {
                    ans.Append(node.val);
                    if (node.left == null && node.right == null)
                    {
                        continue;
                    }
                    nodes.Enqueue(node.left);
                    nodes.Enqueue(node.right);
                }
                else
                {
                    ans.Append("null");
                }
                first = false;
            }
            ans.Append("]");
            return ans.ToString();
        }
    }
}