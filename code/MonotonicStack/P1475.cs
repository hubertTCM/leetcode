
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1475
{
    public class Solution
    {
        public int[] FinalPrices(int[] prices)
        {
            var ans = new int[prices.Length];
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < prices.Length; i++)
            {
                var current = prices[i];
                while (stack.Count > 0 && prices[stack.Peek()] >= current)
                {
                    var top = stack.Pop();
                    ans[top] = prices[top] - current;
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                ans[top] = prices[top];
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(String.Join(",", s.FinalPrices(new int[] { 8, 4, 6, 2, 3 })));//[4,2,4,2,3]
            Console.WriteLine(String.Join(",", s.FinalPrices(new int[] { 1, 2, 3, 4, 5 })));//[1,2,3,4,5]
        }
    }
}
