using System;

// Time exceed.
namespace P91
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            return NumDecodings(s, 0);
        }

        int NumDecodings(string s, int start)
        {
            if (start >= s.Length)
            {
                return 0;
            }
            char first = s[start];
            if (!isValid(first))
            {
                return 0;
            }
            if (start == s.Length - 1)
            {
                return 1;
            }

            int result = NumDecodings(s, start + 1);
            char second = s[start + 1];
            if (isValid(first, second))
            {
                if (start == s.Length - 2)
                {
                    return result + 1;
                }
                result += NumDecodings(s, start + 2);
            }
            return result;
        }

        bool isValid(char x)
        {
            return x >= '1' && x <= '9';
        }

        bool isValid(char x, char y)
        {
            if (x == '1')
            {
                return y >= '0' && y <= '9';
            }
            if (x == '2')
            {
                return y >= '0' && y <= '6';
            }
            return false;
        }
    }


    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            //Console.WriteLine(s.NumDecodings("111111111111111111111111111111111111111111111"));
            Console.WriteLine(s.NumDecodings("1111111111111111111111111111111111111111"));
            Console.WriteLine(s.NumDecodings("12"));
            Console.WriteLine(s.NumDecodings("1116"));
            Console.WriteLine(s.NumDecodings("226"));
            Console.WriteLine(s.NumDecodings("0"));
            Console.WriteLine(s.NumDecodings("06"));
        }
    }
}