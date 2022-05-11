
using System;
using System.Collections.Generic;
using System.Linq;
namespace P413
{
    public class Solution
    {

        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }
            int delta = nums[1] - nums[0];

            int ans = 0;
            var i = 0;
            for (var j = 2; j < nums.Length; j++)
            {
                var currentDelta = nums[j] - nums[j - 1];
                if (currentDelta == delta)
                {
                    // i, i + 1, i + 2, ... j
                    // endpoint is j, 
                    // the start point would be one in [i, i + 1, ..., j-2]
                    ans += j - 2 - i + 1; // TODO:
                }
                else
                {
                    i = j - 1;
                    delta = currentDelta;
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
            Console.WriteLine("");
        }
    }
}
