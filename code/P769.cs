
using System;
using System.Collections.Generic;
using System.Linq;
namespace P769
{
    public class Solution
    {
        public int MaxChunksToSorted(int[] arr)
        {
            var ans = 0;
            var max = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
                if (max == i)
                {
                    ans += 1;
                }
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 4, 3, 2, 1, 0 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 1, 0, 2, 3, 4 })); // 4
        }
    }
}
