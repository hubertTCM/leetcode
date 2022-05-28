
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
            Build(preorder, 0, preorder.Length - 1);
            Console.WriteLine("****");
            return BuildBinarySearch(preorder, 0, preorder.Length - 1);
        }

        // wrong : TBD
        TreeNode BuildBinarySearch(int[] preorder, int from, int to)
        {
            if (from > to)
            {
                return null;
            }

            var val = preorder[from];
            var root = new TreeNode(val);
            var left = from + 1; var right = to;
            var splitIndex = -1;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (preorder[mid] < val)
                {
                    left = mid + 1;
                }
                else
                {
                    splitIndex = mid;
                    right = mid - 1;
                }
            }
            Console.WriteLine($"[{from + 1}, {to}, {splitIndex}]");
            if (splitIndex < 0)
            {
                root.left = BuildBinarySearch(preorder, from + 1, to);
            }
            else if (splitIndex <= to)
            {
                root.left = BuildBinarySearch(preorder, from + 1, splitIndex - 1);
                root.right = BuildBinarySearch(preorder, splitIndex, to);
            }
            else
            {
                root.left = BuildBinarySearch(preorder, from + 1, to);
            }
            // for (var i = from + 1; i <= to; i++)
            // {
            //     if (preorder[i] > val)
            //     {
            //         root.left = BuildBinarySearch(preorder, from + 1, i - 1);
            //         root.right = BuildBinarySearch(preorder, i, to);
            //         return root;
            //     }
            // }
            // root.left = BuildBinarySearch(preorder, from + 1, to);
            return root;
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
                    Console.WriteLine($"[{from + 1}, {to}, {i}]");
                    root.left = Build(preorder, from + 1, i - 1);
                    root.right = Build(preorder, i, to);
                    return root;
                }
            }
            Console.WriteLine($"[{from + 1}, {to}, -1]");
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
