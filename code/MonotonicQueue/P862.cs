
using System;
using System.Collections.Generic;
using System.Linq;
namespace P862
{
    public class Solution
    {
        public int ShortestSubarray(int[] nums, int k)
        {
            var ans = -1;

            var left = -1;
            var right = -1;
            var total = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                if (total <= 0)
                {
                    left = -1;
                    right = -1;
                    total = 0;
                    continue;
                }
                right += 1;
                if (left < 0)
                {
                    left = i;
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
            Console.WriteLine(s.ShortestSubarray(new int[] { 1 }, 1)); // 1
            Console.WriteLine(s.ShortestSubarray(new int[] { 1, 2 }, 4)); // -1
            Console.WriteLine(s.ShortestSubarray(new int[] { 2, -1, 2 }, 3)); // 3
        }
    }
}
