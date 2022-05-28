
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1944
{
    public class Solution
    {
        public int[] CanSeePersonsCount(int[] heights)
        {
            var ans = new int[heights.Length];
            var stack = new Stack<int>();
            for (var i = heights.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[i] > heights[stack.Peek()])
                {
                    ans[i] += 1;
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    ans[i] += 1;
                }
                stack.Push(i);
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(String.Join(",", s.CanSeePersonsCount(new int[] { 10, 6, 8, 5, 11, 9 }))); // [3,1,2,1,1,0]
            Console.WriteLine(String.Join(",", s.CanSeePersonsCount(new int[] { 1, 2, 3, 4, 5 }))); // [1,1,1,1,0]
        }
    }
}
