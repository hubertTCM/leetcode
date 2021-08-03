using System;
using System.Collections.Generic;
namespace P1124
{
    public class Solution
    {
        public int LongestWPI(int[] hours)
        {
            int[] total = new int[hours.Length + 1];
            for (var t = 1; t < total.Length; t++)
            {
                var delta = hours[t - 1] > 8 ? 1 : -1;
                total[t] = total[t - 1] + delta;
            }
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < total.Length; i++)
            {
                var top = stack.Peek();
                if (total[top] > total[i])
                {
                    stack.Push(i);
                }
            }
            var result = 0;
            for (var i = total.Length - 1; i > 0 && stack.Count > 0; i--)
            {
                while (stack.Count > 0 && total[stack.Peek()] < total[i])
                {
                    var top = stack.Pop();
                    result = Math.Max(i - top, result);
                }
            }
            return result;
        }
        // wrong
        public int LongestWPIWrong(int[] hours)
        {
            int[] total = new int[hours.Length + 1];
            for (var t = 1; t < total.Length; t++)
            {
                var delta = hours[t - 1] > 8 ? 1 : -1;
                total[t] = total[t - 1] + delta;
            }
            int i = 1;
            int j = total.Length - 1;
            int iCache = -1;
            int iCacheNext = -1;
            int jCache = -1;
            int jCacheNext = -1;
            while (i < j)
            {
                if (total[j] - total[i] > 0)
                {
                    return j - i;
                }
                var iNext = -1;
                if (i == iCache)
                {
                    iNext = iCacheNext;
                }
                else
                {
                    iCache = -1;
                    var temp = (i > 0 && hours[i - 1] > 8) ? (i + 2) : (i + 1);
                    for (; temp < j; temp++)
                    {
                        if (total[temp] - total[i] < 0)
                        {
                            iCache = i;
                            iCacheNext = temp;
                            iNext = temp;
                            break;
                        }
                    }
                }
                var jNext = -1;
                if (jCache == j)
                {
                    jNext = jCacheNext;
                }
                else
                {
                    jCache = -1;
                    var temp = (hours[j - 1] > 8) ? (j - 2) : (j - 1);
                    for (; temp > i; temp--)
                    {
                        if (total[j] - total[temp] < 0)
                        {
                            jCache = j;
                            jNext = temp;//- 1;
                            jCacheNext = jNext;
                            break;
                        }
                    }
                }

                if (iNext < 0 && jNext < 0)
                {
                    Console.WriteLine("error");
                }

                if (iNext > 0 && jNext > 0)
                {
                    if (iNext - i < j - jNext)
                    {
                        i = iNext;
                        iCache = -1;
                    }
                    else
                    {
                        j = jNext;
                        jCache = -1;
                    }
                }
                else
                {
                    if (iNext > 0)
                    {
                        i = iNext;
                        iCache = -1;
                        jCache = j;
                    }
                    else
                    {
                        j = jNext;
                        iCache = i;
                    }
                }
            }
            return 0;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.LongestWPI(new int[] { 12, 8, 7, 7, 9, 10, 8, 7, 9, 7, 8, 11 })); // 5
            Console.WriteLine(s.LongestWPI(new int[] { 5, 5, 9, 9, 5, 6, 10, 8, 8, 10, 5, 5, 7 })); // 5
            Console.WriteLine(s.LongestWPI(new int[] { 12, 8, 7, 7, 9, 10, 8, 7, 9, 7, 8, 11 }));// 5
            Console.WriteLine(s.LongestWPI(new int[] { 10, 5, 9, 7, 9, 9, 5, 5, 7, 10 }));// 7
            Console.WriteLine(s.LongestWPI(new int[] { 13, 4, 2, 5, 0, 6, 0, 10, 5, 12, 5 })); // 3
            Console.WriteLine(s.LongestWPI(new int[] { 8, 7, 7, 8, 6, 11, 12 })); // 3
            Console.WriteLine(s.LongestWPI(new int[] { 14, 7, 6, 14, 15, 0, 3, 4, 10, 5, 1, 8, 16, 7 })); // 5
            Console.WriteLine(s.LongestWPI(new int[] { 9, 9, 6, 0, 6, 6, 9 })); //3
            Console.WriteLine(s.LongestWPI(new int[] { 6, 6, 9 })); // 1
            Console.WriteLine(s.LongestWPI(new int[] { 9, 6, 6 })); // 1
        }
    }
}