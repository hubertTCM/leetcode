
using System;
using System.Collections.Generic;
using System.Linq;
namespace P926
{
    public class Solution
    {
        public int MinFlipsMonoIncr(string s)
        {
            var totalZero = 0;
            foreach (var ch in s)
            {
                if (ch == '0')
                {
                    totalZero += 1;
                }
            }

            var ans = Math.Min(s.Length - totalZero, totalZero); // flip all to 0, all to 1
            if (ans == 0)
            {
                return 0;
            }

            var leftOne = 0;
            var rightZero = totalZero;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    rightZero -= 1;
                }
                else
                {
                    leftOne += 1;
                }
                // flip [0, i] to 0 and [i+1, s.Length -1] to 1
                ans = Math.Min(ans, leftOne + rightZero);
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.MinFlipsMonoIncr("0111")); // 0
            Console.WriteLine(s.MinFlipsMonoIncr("10000")); // 1
            Console.WriteLine(s.MinFlipsMonoIncr("1110")); // 1
            Console.WriteLine(s.MinFlipsMonoIncr("00110")); // 1
            Console.WriteLine(s.MinFlipsMonoIncr("010110")); // 2
            Console.WriteLine(s.MinFlipsMonoIncr("00011000")); // 2
            Console.WriteLine("");
        }
    }
}
