
using System;
using System.Collections.Generic;
using System.Linq;
namespace P907
{
    public class Solution
    {
        public int SumSubarrayMins(int[] arr)
        {
            var mod = 1_000_000_007L;
            var ans = 0L;
            var stack = new Stack<int>();
            var right = -1;
            for (var i = 0; i < arr.Length; i++)
            {
                right = i - 1;
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    var top = stack.Pop();
                    var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                    // [left, top]: top -left  [top, right]: right - top + 1
                    ans += ((top - left + 1) * (right - top + 1) % mod) * (arr[top] % mod);
                    ans %= mod;
                }
                stack.Push(i);
            }

            right = arr.Length - 1;
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                var left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                // [left, top -1]: top -left  [top, right]: right - top + 1
                ans += ((top - left + 1) * (right - top + 1) % mod) * (arr[top] % mod);
                ans %= mod;
            }

            return Convert.ToInt32(ans);
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.SumSubarrayMins(new int[] { 3, 1, 2, 4 })); // 17
            Console.WriteLine(s.SumSubarrayMins(new int[] { 11, 81, 94, 43, 3 })); // 444
            Console.WriteLine(s.SumSubarrayMins(new int[] { 1, 1 })); // 3
            Console.WriteLine(s.SumSubarrayMins(new int[] { 1, 1, 1 })); // 6
        }
    }
}
