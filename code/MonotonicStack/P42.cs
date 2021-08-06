using System;
using System.Collections.Generic;
namespace P42
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            var stack = new Stack<int>();
            var ans = 0;
            for (var i = 0; i < height.Length; i++)
            {
                var rightIndex = i;
                while (stack.Count > 0 && height[stack.Peek()] < height[i]) // increase from top to bottom
                {
                    var temp = stack.Pop();
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    var leftIndex = stack.Peek();
                    ans += (rightIndex - leftIndex - 1) * (Math.Min(height[i], height[leftIndex]) - height[temp]);
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
            Console.WriteLine(s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));//6
            Console.WriteLine(s.Trap(new int[] { 4, 2, 0, 3, 2, 5 }));//9
        }
    }
}