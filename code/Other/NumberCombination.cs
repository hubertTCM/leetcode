/*
Given a number N, find all the combinations with N = a1 + a2 + ... + ak (ax = 1, 2) 
*/

using System;
using System.Collections.Generic;

namespace NumberCombination
{
    public class Solution
    {
        List<List<int>> answer = new List<List<int>>();
        public List<List<int>> Combination(int n)
        {
            answer.Clear();
            Combination(n, new List<int>());
            return answer;
        }

        void Combination(int n, List<int> result)
        {
            if (n < 0)
            {
                return;
            }
            if (n == 0)
            {
                answer.Add(result);
                return;
            }

            for (var k = 1; k < 3 && k <= n; k++)
            {
                var next = new List<int>(result);
                next.Add(k);
                Combination(n - k, next);
            }
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{i} ======");

                var answer = s.Combination(i);
                foreach (var item in answer)
                {
                    foreach (var temp in item)
                    {
                        Console.Write($"{temp}, ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("=====");
            }
        }
    }
}