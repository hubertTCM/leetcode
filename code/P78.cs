using System;
using System.Collections.Generic;
using System.Linq;
namespace P78
{
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var current = new List<int>();
            var ans = new List<IList<int>>();
            Subsets(0, nums, ans, current);
            return ans;
        }

        void Subsets(int start, int[] nums, IList<IList<int>> all, IList<int> current)
        {
            if (start == nums.Length)
            {
                all.Add(new List<int>(current));
                return;
            }
            current.Add(nums[start]);
            Subsets(start + 1, nums, all, current);
            current.RemoveAt(current.Count - 1);
            Subsets(start + 1, nums, all, current);
        }
    }

    public static class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.Subsets(new int[] { 1, 2, 3 }).Display());
        }

        static string Display(this IList<IList<int>> source)
        {
            return $"[{string.Join(",", source.Select(x => x.Display()))}]";
        }
        static string Display(this IList<int> source)
        {
            return $"[{string.Join(",", source)}]";
        }
    }
}