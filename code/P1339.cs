
using System;
using System.Collections.Generic;
using System.Linq;
using Tree;
namespace P1339
{
    public class Solution
    {

        public int MaxProduct(TreeNode root)
        {
            var cache = new Dictionary<TreeNode, int>();
            CalculateTotal(root, cache);
            long closest = 0L;
            var queue = new Queue<TreeNode>();
            var total = cache[root];
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    var temp = cache[node.left];
                    if (Math.Abs(temp * 2 - total) < Math.Abs(closest * 2 - total))
                    {
                        closest = temp;
                    }
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    var temp = cache[node.right];
                    if (Math.Abs(temp * 2 - total) < Math.Abs(closest * 2 - total))
                    {
                        closest = temp;
                    }
                }
            }
            var mode = 1000000007;
            return Convert.ToInt32(((closest % mode) * ((total - closest) % mode)) % mode);
        }

        // Maybe overflow?
        public int MaxProductIncorrect(TreeNode root)
        {
            var cache = new Dictionary<TreeNode, int>();
            CalculateTotal(root, cache);
            long max = 0L;
            var queue = new Queue<TreeNode>();
            var total = cache[root];
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    var temp = cache[node.left];
                    max = Math.Max(max, (total - temp) * temp);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    var temp = cache[node.right];
                    max = Math.Max(max, (total - temp) * temp);
                }
            }
            return Convert.ToInt32(max % (1000000007));
        }

        int CalculateTotal(TreeNode root, Dictionary<TreeNode, int> result)
        {
            if (root == null)
            {
                return 0;
            }
            var total = CalculateTotal(root.left, result) + CalculateTotal(root.right, result) + root.val;
            result[root] = total;
            return total;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var data = new List<string>();
            data.Add("[1,2,3,4,5,6]");//110
            data.Add("[1,null,2,3,4,null,null,5,6]");//90
            data.Add("[2,3,9,10,7,8,6,5,4,11,1]");//1025
            data.Add("[1,1]");//1
            foreach (var item in data)
            {
                var node = TreeHelper.Build(item);
                Console.WriteLine(s.MaxProduct(node));
            }
        }
    }
}
