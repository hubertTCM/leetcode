
using System;
using System.Collections.Generic;
using System.Linq;
namespace P925
{
    public class Solution
    {
        public bool IsLongPressedName(string name, string typed)
        {
            if (typed.Length < name.Length)
            {
                return false;
            }
            var i = 0;
            var j = 0;
            for (i = 0; i < name.Length && j < typed.Length; i++)
            {
                if (name[i] == typed[j])
                {
                    j++;
                    continue;
                }
                if (j == 0)
                {
                    return false;
                }
                while (j < typed.Length && typed[j] == typed[j - 1])
                {
                    j++;
                }
                if (j == typed.Length || name[i] != typed[j])
                {
                    return false;
                }
                j++;
            }
            while (j < typed.Length && typed[j] == typed[j - 1])
            {
                j++;
            }

            return i == name.Length && j == typed.Length;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.IsLongPressedName("a", "b"));
            Console.WriteLine(s.IsLongPressedName("aa", "ab"));
            Console.WriteLine(s.IsLongPressedName("alex", "aaleexa"));
            Console.WriteLine(s.IsLongPressedName("pyplrz", "ppyypllr"));
            Console.WriteLine("===");
            Console.WriteLine(s.IsLongPressedName("alex", "aaleex"));
            Console.WriteLine(s.IsLongPressedName("alex", "aaleexxxx"));
            Console.WriteLine(s.IsLongPressedName("a", "aaa"));
        }
    }
}
