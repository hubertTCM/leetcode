
using System;
using System.Collections.Generic;
using System.Linq;
namespace P496
{
    public class Solution
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var ans = new int[nums1.Length];
            var stack = new Stack<int>();
            stack.Push(0);
            var greater = new Dictionary<int, int>();
            for (var i = 1; i < nums2.Length; i++)
            {
                var item = nums2[i];
                while (stack.Count > 0 && item > nums2[stack.Peek()])
                {
                    var temp = stack.Pop();
                    greater[nums2[temp]] = item;
                }
                stack.Push(i);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                if (greater.ContainsKey(nums1[i]))
                {
                    ans[i] = greater[nums1[i]];
                }
                else
                {
                    ans[i] = -1;
                }
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(String.Join(",", s.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }))); // [-1,3,-1]
        }
    }
}
