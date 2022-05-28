
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace P402
{
    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length <= k)
            {
                return "0";
            }
            var stack = new Stack<char>();
            var removed = 0;
            for (var i = 0; i < num.Length; i++)
            {
                var ch = num[i];
                while (stack.Count > 0 && removed < k && stack.Peek() > ch)
                {
                    removed += 1;
                    stack.Pop();
                }
                stack.Push(ch);
            }

            while (removed < k)
            {
                stack.Pop();
                removed += 1;
            }

            var ans = new StringBuilder();
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                ans.Insert(0, top);
            }
            while (ans.Length > 0 && ans[0] == '0')
            {
                ans.Remove(0, 1);
            }
            return ans.Length == 0 ? "0" : ans.ToString();
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.RemoveKdigits("1432219", 3));// 1219
            Console.WriteLine(s.RemoveKdigits("10200", 1)); // 200 
            Console.WriteLine(s.RemoveKdigits("112", 1)); // 11 
        }
    }
}
