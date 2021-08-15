
using System;
using System.Collections.Generic;
using System.Linq;
namespace P739
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            var ans = new int[temperatures.Length];
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    var top = stack.Pop();
                    ans[top] = i - top;
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
            Console.WriteLine(String.Join(",", s.DailyTemperatures(new int[] { 30, 60, 90 }))); // [1,1,0]
            Console.WriteLine(String.Join(",", s.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }))); // [1,1,4,2,1,1,0,0]
        }
    }
}
