using System;
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
            int deltaLength = 1;
            int ans = 0;
            for (var end = 2; end < nums.Length; end++)
            {
                var current = nums[end] - nums[end - 1];
                if (current == delta)
                {
                    deltaLength += 1;
                }
                else
                {
                    ans += deltaLength * (deltaLength - 1) / 2;
                    delta = current;
                    deltaLength = 1;
                }
            }

            ans += deltaLength * (deltaLength - 1) / 2;

            return ans;
        }
    }


    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 })); // 3

            Console.WriteLine(s.NumberOfArithmeticSlices(new int[] { 1, 2, 3 })); // 1
        }
    }
}