
using System;
using System.Collections.Generic;
using System.Linq;
namespace P503
{
    public class Solution
    {
        public int[] NextGreaterElements(int[] nums)
        {
            var ans = new int[nums.Length];
            for (var i = 0; i < ans.Length; i++)
            {
                ans[i] = -1;
            }
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < 2 * nums.Length - 1; i++)
            {
                var index = i % nums.Length;
                while (stack.Count > 0 && nums[stack.Peek()] < nums[index])
                {
                    var top = stack.Pop();
                    ans[top] = nums[index];
                }
                stack.Push(index);
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(String.Join(",", s.NextGreaterElements(new int[] { 1, 2, 1 }))); // [2,-1,2]
        }
    }
}
