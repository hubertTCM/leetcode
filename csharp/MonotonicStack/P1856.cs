
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1856
{
    public class Solution
    {
        public int MaxSumMinProduct(int[] nums)
        {
            var ans = 0L;
            var sum = new long[nums.Length + 1];
            for (var i = 1; i < sum.Length; i++)
            {
                sum[i] = nums[i - 1] + sum[i - 1];
            }
            var stack = new Stack<int>();
            var right = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                right = i - 1;
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    var top = nums[stack.Pop()];
                    var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                    ans = Math.Max(ans, (sum[right + 1] - sum[left]) * top);
                }
                stack.Push(i);
            }
            right = nums.Length - 1;
            while (stack.Count > 0)
            {
                var top = nums[stack.Pop()];
                var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                ans = Math.Max(ans, (sum[right + 1] - sum[left]) * top);
            }
            return Convert.ToInt32(ans % 1000000007);
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.MaxSumMinProduct(new int[] { 1, 2, 3, 2 }));//14
            Console.WriteLine(s.MaxSumMinProduct(new int[] { 2, 3, 3, 1, 2 }));//18
            Console.WriteLine(s.MaxSumMinProduct(new int[] { 3, 1, 5, 6, 4, 2 }));//60
        }
    }
}
