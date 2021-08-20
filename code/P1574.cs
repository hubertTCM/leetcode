
using System;
using System.Collections.Generic;
using System.Linq;
namespace P1574
{
    public class Solution
    {
        // non-decreasing
        public int FindLengthOfShortestSubarray(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left] > arr[left + 1] || arr[right - 1] > arr[right] || arr[left] > arr[right])
                {
                    break;
                }

                // hmm, incorrect here.
                if (arr[left + 1] - arr[left] < arr[right] - arr[right - 1])
                {
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }
            if (left == right)
            {
                return 0;
            }
            var min = right - left;
            for (var i = Math.Max(left - 1, 0); i < arr.Length; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    min = Math.Min(min, arr.Length - (i + 1));
                    break;
                }
            }
            for (var i = Math.Min(right + 1, arr.Length - 1); i >= 0; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    min = Math.Min(min, i);
                    break;
                }
            }
            return min;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            // Console.WriteLine(s.FindLengthOfShortestSubarray(new int[] { 1, 2, 3, 10, 4, 2, 3, 5 })); // 3
            // Console.WriteLine(s.FindLengthOfShortestSubarray(new int[] { 5, 4, 3, 2, 1 })); // 4
            // Console.WriteLine(s.FindLengthOfShortestSubarray(new int[] { 1, 2, 3 })); // 0
            // Console.WriteLine(s.FindLengthOfShortestSubarray(new int[] { 1 })); // 0
            Console.WriteLine(s.FindLengthOfShortestSubarray(new int[] { 1, 3, 2, 4 })); // 3
        }
    }
}
