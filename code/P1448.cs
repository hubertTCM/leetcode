
using System;
using System.Collections.Generic;
using System.Linq;
using Tree;
namespace P1448
{


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

            Console.WriteLine(s.GoodNodes(TreeHelper.Build("[3,1,4,3,null,1,5]")));//4
            Console.WriteLine(s.GoodNodes(TreeHelper.Build("[3,3,null,4,2]")));//3
            Console.WriteLine(s.GoodNodes(TreeHelper.Build("[2,null,4,10,8,null,null,4]"))); //4

            var node = TreeHelper.Build("[3,1,4,3,null,1,5]");
            Console.WriteLine(node.Display());
        }
    }
}
