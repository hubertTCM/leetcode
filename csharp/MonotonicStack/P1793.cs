
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1793
{
    public class Solution
    {
        public int MaximumScore(int[] nums, int k)
        {
            var ans = 0;
            var stack = new Stack<int>();
            var right = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                right = i - 1;
                while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
                {
                    // i <= k <= j
                    var top = nums[stack.Pop()];
                    var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                    if (right >= k && left <= k)
                    {
                        ans = Math.Max(ans, top * (right - left + 1));
                    }
                }
                stack.Push(i);
            }
            right = nums.Length - 1;
            while (stack.Count > 0)
            {
                var top = nums[stack.Pop()];
                var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                if (right >= k && left <= k)
                {
                    ans = Math.Max(ans, top * (right - left + 1));
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
            Console.WriteLine(s.MaximumScore(new int[] { 1, 4, 3, 7, 4, 5 }, 3));//15
            Console.WriteLine(s.MaximumScore(new int[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 0));//20
        }
    }
}
