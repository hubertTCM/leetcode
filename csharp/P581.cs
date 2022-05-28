
using System;
using System.Collections.Generic;
using System.Linq;
namespace P581
{
    public class Solution
    {

        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            var sorted = new int[nums.Length];
            Array.Copy(nums, sorted, nums.Length);
            Array.Sort(sorted);
            var left = -1; var right = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != sorted[i])
                {
                    left = i;
                    break;
                }
            }
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] != sorted[i])
                {
                    right = i;
                    break;
                }
            }

            if (right < 0)
            {
                return 0;
            }
            return right - left + 1;
        }

        // Not understand yet.
        public int FindUnsortedSubarray2(int[] nums)
        {
            int n = nums.Length;
            int maxn = int.MinValue, right = -1;
            int minn = int.MaxValue, left = -1;
            for (int i = 0; i < n; i++)
            {
                if (maxn > nums[i])
                {
                    right = i;
                }
                else
                {
                    maxn = nums[i];
                }
                if (minn < nums[n - i - 1])
                {
                    left = n - i - 1;
                }
                else
                {
                    minn = nums[n - i - 1];
                }
            }
            return right == -1 ? 0 : right - left + 1;
        }

    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 })); // 5
            Console.WriteLine(s.FindUnsortedSubarray(new int[] { 1, 2, 3, 4, 5 })); // 0
        }
    }
}
