using System;
using System.Collections.Generic;
namespace P84
{
    public class Solution
    {
        // Monotone Stack
        public int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>(); // height decrease from top to bottom
            var ans = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    var temp = stack.Pop();
                    var h = heights[temp];
                    var leftMostIndex = stack.Count == 0 ? 0 : (stack.Peek() + 1);
                    var rightMostIndex = i - 1;
                    var w = rightMostIndex - leftMostIndex + 1;
                    ans = Math.Max(ans, w * h);
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                var h = heights[stack.Pop()];
                var leftMostIndex = stack.Count == 0 ? 0 : (stack.Peek() + 1);
                var rightMostIndex = heights.Length - 1;
                var w = rightMostIndex - leftMostIndex + 1;
                ans = Math.Max(ans, w * h);
            }
            return ans;
        }

    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.LargestRectangleArea(new int[] { 2, 4 }));
            Console.WriteLine(s.LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 }));
        }
    }

}