
using System;
using System.Collections.Generic;
using System.Linq;
using Tree;
namespace P1008
{
    public class Solution
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            return Build(preorder, 0, preorder.Length - 1);
        }

        TreeNode Build(int[] preorder, int from, int to)
        {
            if (from > to)
            {
                return null;
            }

            var val = preorder[from];
            var root = new TreeNode(val);
            for (var i = from + 1; i <= to; i++)
            {
                if (preorder[i] > val)
                {
                    root.left = Build(preorder, from + 1, i - 1);
                    root.right = Build(preorder, i, to);
                    return root;
                }
            }
            root.left = Build(preorder, from + 1, to);
            return root;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var data = new List<int[]>();
            data.Add(new int[] { 8, 5, 1, 7, 10, 12 }); // [8,5,10,1,7,null,12]
            foreach (var item in data)
            {
                var node = s.BstFromPreorder(item);
                Console.WriteLine(node.Display());
            }
        }
    }
}
