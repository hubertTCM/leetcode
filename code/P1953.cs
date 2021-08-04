using System;
using System.Collections.Generic;
namespace P1953
{
    public class Solution
    {
        public long NumberOfWeeks(int[] milestones)
        {
            // wrong:
            // Array.Sort(milestones);
            // long finishedMilestones = 0;
            // long ans = 0;
            // for (var i = 0; i < milestones.Length; i++)
            // {
            //     var left = milestones[i] - finishedMilestones;
            //     if (left == 0)
            //     {
            //         continue;
            //     }
            //     if (i == milestones.Length - 1)
            //     {
            //         ans += Math.Min(1L, left);
            //     }
            //     else
            //     {
            //         ans += (milestones.Length - i) * left;
            //     }
            //     finishedMilestones += left;
            // }
            // return ans;
            long longest = 0L;
            long rest = 0L;
            for (var i = 0; i < milestones.Length; i++)
            {
                longest = Math.Max(milestones[i], longest);
                rest += milestones[i];
            }
            rest -= longest;
            if (longest >= rest + 1)
            {
                return rest * 2 + 1;
            }
            return rest + longest;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.NumberOfWeeks(new int[] { 3, 2, 1 }));
            Console.WriteLine(s.NumberOfWeeks(new int[] { 4, 2, 1 }));
            Console.WriteLine(s.NumberOfWeeks(new int[] { 5, 2, 1 }));
        }
    }
}