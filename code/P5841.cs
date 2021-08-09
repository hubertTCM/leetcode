using System;
using System.Collections.Generic;
namespace P5841
{
    public class Solution
    {
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            var ans = new int[obstacles.Length];
            ans[0] = 1;
            var minValues = new int[obstacles.Length + 1];
            minValues[1] = obstacles[0];
            var len = 1;
            for (var i = 1; i < obstacles.Length; i++)
            {
                var current = obstacles[i];
                if (minValues[len] <= current)
                {
                    len += 1;
                    minValues[len] = current;
                    ans[i] = len;
                }
                else
                {
                    var left = 1;
                    var right = len;
                    var pos = 0;
                    while (left <= right)
                    {
                        var mid = (left + right) / 2;
                        if (minValues[mid] <= current)
                        {
                            pos = mid;
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    pos += 1;
                    minValues[pos] = current;
                    ans[i] = pos;
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
            Console.WriteLine(String.Join(",", s.LongestObstacleCourseAtEachPosition(new int[] { 1, 2, 3, 2 }))); // [1, 2, 3, 3]
            Console.WriteLine(String.Join(",", s.LongestObstacleCourseAtEachPosition(new int[] { 2, 2, 1 }))); // [1,2,1]
            Console.WriteLine(String.Join(",", s.LongestObstacleCourseAtEachPosition(new int[] { 3, 1, 5, 6, 4, 2 }))); // [1,1,2,3,2,2]
        }
    }
}