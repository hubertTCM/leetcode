
using System;
using System.Collections.Generic;
namespace P962
{
    public class Solution
    {
        public int MaxWidthRamp(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < nums.Length; i++)
            {
                var top = stack.Peek();
                if (nums[top] > nums[i])
                {
                    stack.Push(i);
                }
            }
            var result = 0;
            for (var i = nums.Length - 1; i > 0 && stack.Count > 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    var top = stack.Pop();
                    result = Math.Max(i - top, result);
                }
            }
            return result;
        }
    }

    public class Test
    {
        public static void Run()
        {

            var s = new Solution();
            Console.WriteLine(s.MaxWidthRamp(new int[] { 6, 0, 8, 2, 1, 5 })); // 4
            Console.WriteLine(s.MaxWidthRamp(new int[] { 9, 8, 1, 0, 1, 9, 4, 0, 4, 1 })); // 7
        }
    }
}