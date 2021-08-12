using System;
using System.Collections.Generic;

namespace P768
{
    public class Solution
    {
        // incorrect
        public int MaxChunksToSorted(int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr.Length;
            }
            var chunks = new Stack<(int min, int max)>();
            chunks.Push((arr[0], arr[0]));

            var shouldReverse = false;
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    shouldReverse = true;
                }
                var item = arr[i];
                var previousChunk = chunks.Peek();
                if (previousChunk.max <= item)
                {
                    chunks.Push((item, item));
                    continue;
                }
                var max = previousChunk.max;
                var min = item;
                while (chunks.Count > 0)
                {
                    var current = chunks.Peek();
                    min = current.min;
                    if (current.max <= item)
                    {
                        chunks.Push((item, max));
                        break;
                    }
                    if (current.min <= item)
                    {
                        current.max = max;
                        chunks.Pop();
                        chunks.Push(current);
                        break;
                    }
                    chunks.Pop();
                    previousChunk = current;
                }
                if (chunks.Count == 0)
                {
                    min = Math.Min(min, item);
                    chunks.Push((min, max));
                }
            }
            if (chunks.Count == 1 && !shouldReverse)
            {
                return 0;
            }
            return chunks.Count;
        }



        public int MaxChunksToSorted2(int[] arr)
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
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 5, 1, 1, 8, 1, 6, 5, 9, 7, 8 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 0, 3, 0, 3, 2 }));// 2
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 3, 0, 3, 0, 2 }));// 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 1 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 4, 3, 2, 1 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 2, 1, 3, 4, 4 })); // 4
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 5, 4, 3, 2, 1 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 4, 4, 4, 4, 4 })); // 5
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 1, 0, 1, 3, 2 })); // 3
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 1 })); // 1
            Console.WriteLine(s.MaxChunksToSorted(new int[] { 4, 2, 2, 1, 1 }));// 1
        }
    }
}