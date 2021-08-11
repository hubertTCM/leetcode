using System;
using System.Collections.Generic;

namespace P768
{
    public class Solution
    {
        public int MaxChunksToSorted(int[] arr)
        {
            if (arr.Length == 1)
            {
                return 1;
            }
            var chunks = new List<(int min, int max)>();
            chunks.Add((arr[0], arr[0]));
            var shouldReverse = false;
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    shouldReverse = true;
                }
                var item = arr[i];
                var last = chunks[chunks.Count - 1];
                if (item < last.max)
                {
                    if (last.min > item)
                    {
                        var j = chunks.Count - 2;
                        var chunk = last;
                        for (; j >= 0; j--)
                        {
                            chunk = chunks[j];
                            if (chunk.min <= item)
                            {
                                break;
                            }
                        }
                        chunk.max = last.max;
                        chunks.RemoveRange(j + 1, chunks.Count - j - 2);
                    }
                }
                else
                {
                    chunks.Add((item, item));
                }
            }
            if (chunks.Count == 1)
            {
                if (shouldReverse)
                {
                    return 1;
                }
                return 0;
            }
            return chunks.Count;
        }
    }



    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(String.Join(",", s.MaxChunksToSorted(new int[] { 4, 3, 2, 1 }))); // 1
            Console.WriteLine(String.Join(",", s.MaxChunksToSorted(new int[] { 2, 1, 3, 4, 4 }))); // 4
            Console.WriteLine(String.Join(",", s.MaxChunksToSorted(new int[] { 5, 4, 3, 2, 1 }))); // 1
            Console.WriteLine(String.Join(",", s.MaxChunksToSorted(new int[] { 4, 4, 4, 4, 4 }))); // 5
        }
    }
}