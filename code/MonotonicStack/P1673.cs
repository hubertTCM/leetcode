
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1673
{
    public class Solution
    {
        public int[] MostCompetitive(int[] nums, int k)
        {
            if (k >= nums.Length)
            {
                return nums;
            }
            var ans = new int[k];
            var stack = new Stack<int>();
            var removedCount = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] > nums[i] && removedCount < nums.Length - k)
                {
                    stack.Pop();
                    removedCount += 1;
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                if (stack.Count <= k)
                {
                    ans[stack.Count - 1] = nums[stack.Peek()];
                }
                stack.Pop();
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(string.Join(",", s.MostCompetitive(new int[] { 3, 5, 2, 6 }, 2))); // 2, 6
            Console.WriteLine(string.Join(",", s.MostCompetitive(new int[] { 2, 4, 3, 3, 5, 4, 9, 6 }, 4))); // 2,3,3,4
        }
    }
}
