using System;

namespace P91
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            var result = new int[s.Length];
            // f[start] = f[start-1] + f[start - 2]
            for (var start = s.Length - 1; start >= 0; start--)
            {
                var startChar = s[start];
                if (!isValid(startChar))
                {
                    result[start] = 0;
                    continue;
                }
                if (start == s.Length - 1)
                {
                    result[start] = 1;
                    continue;
                }
                result[start] += result[start + 1];
                var nextChar = s[start + 1];
                if (isValid(startChar, nextChar))
                {
                    if (start == s.Length - 2)
                    {
                        result[start] += 1;
                    }
                    else
                    {
                        result[start] += result[start + 2];
                    }
                }
            }
            return result[0];
        }

        public int NumDecodingsMemo(string s)
        {
            var cache = new int[s.Length];
            for (var i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            return NumDecodingsMemo(s, 0, cache);
        }

        int NumDecodingsMemo(string s, int start, int[] cache)
        {
            if (start >= s.Length)
            {
                cache[start] = 0;
                return 0;
            }
            if (cache[start] >= 0)
            {
                return cache[start];
            }
            char first = s[start];
            if (!isValid(first))
            {
                cache[start] = 0;
                return 0;
            }
            if (start == s.Length - 1)
            {
                cache[start] = 1;
                return 1;
            }

            int result = NumDecodingsMemo(s, start + 1, cache);
            char second = s[start + 1];
            if (isValid(first, second))
            {
                if (start == s.Length - 2)
                {
                    cache[start] = result + 1;
                    return result + 1;
                }
                result += NumDecodingsMemo(s, start + 2, cache);
            }
            cache[start] = result;
            return result;
        }

        public int NumDecodingsDPOptimization(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            int result = 0;
            int previous = 1;
            int beforePrevious = 0;
            // result[i]=result[i-1] + result[i-2]
            for (var i = 1; i < s.Length + 1; i++)
            {
                result = 0;
                var endChar = s[i - 1];

                if (isValid(endChar))
                {
                    if (i == 1)
                    {
                        result = 1;
                    }
                    else
                    {
                        result += previous;
                    }
                }

                if (i > 1)
                {
                    var previousEndChar = s[i - 2];
                    if (isValid(previousEndChar, endChar))
                    {
                        result += beforePrevious;
                    }
                }

                beforePrevious = previous;
                previous = result;
            }
            return result;
        }

        public int NumDecodingsDP(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            int[] result = new int[s.Length + 1];
            result[0] = 1;
            // result[i]=result[i-1] + result[i-2]
            for (var i = 1; i < s.Length + 1; i++)
            {
                var endChar = s[i - 1];
                if (i > 1)
                {
                    var previousEndChar = s[i - 2];
                    if (isValid(previousEndChar, endChar))
                    {
                        result[i] += result[i - 2];
                    }
                }
                if (isValid(endChar))
                {
                    result[i] += result[i - 1];
                }
            }
            return result[s.Length];
        }

        public int NumDecodingsTLE(string s)
        {
            return NumDecodingsTLE(s, 0);
        }

        int NumDecodingsTLE(string s, int start)
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

            int result = NumDecodingsTLE(s, start + 1);
            char second = s[start + 1];
            if (isValid(first, second))
            {
                if (start == s.Length - 2)
                {
                    return result + 1;
                }
                result += NumDecodingsTLE(s, start + 2);
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
            Console.WriteLine(s.NumDecodings("111111111111111111111111111111111111111111111"));
            Console.WriteLine(s.NumDecodings("1111111111111111111111111111111111111111"));
            Console.WriteLine(s.NumDecodings("12"));
            Console.WriteLine(s.NumDecodings("226"));
            Console.WriteLine(s.NumDecodings("1116"));
            Console.WriteLine(s.NumDecodings("0"));
            Console.WriteLine(s.NumDecodings("06"));
            Console.WriteLine(s.NumDecodings("10"));
        }
    }
}