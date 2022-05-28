
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace P316
{
    public class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var ans = new StringBuilder();
            var count = new int[26];
            var used = new bool[26];
            for (var i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (!used[ch - 'a'])
                {
                    while (stack.Count > 0 && stack.Peek() >= ch)
                    {
                        var top = stack.Peek();
                        if (count[top - 'a'] == 0)
                        {
                            break;
                        }
                        used[top - 'a'] = false;
                        stack.Pop();
                    }

                    stack.Push(ch);
                    used[ch - 'a'] = true;
                }
                count[ch - 'a']--;
            }
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                ans.Insert(0, top);
            }
            return ans.ToString();
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.RemoveDuplicateLetters("bcabc"));
            Console.WriteLine(s.RemoveDuplicateLetters("cbacdcbc")); //acdb
        }
    }
}
