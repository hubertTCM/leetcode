
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1695
{
    public class Solution
    {
        public int MaximumUniqueSubarray(int[] nums)
        {
            var ans = 0;
            var cache = new Dictionary<int, int>(); // value:index
            var start = 0;
            var total = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var item = nums[i];
                if (cache.ContainsKey(item))
                {
                    var temp = cache[item];
                    for (var j = start; j <= temp; j++)
                    {
                        total -= nums[j];
                        cache.Remove(nums[j]);
                    }
                    start = temp + 1;
                }
                cache[item] = i;
                total += item;
                ans = Math.Max(ans, total);
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.MaximumUniqueSubarray(new int[] { 4, 2, 4, 5, 6 })); // 17
            Console.WriteLine(s.MaximumUniqueSubarray(new int[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 })); // 8
        }
    }
}
