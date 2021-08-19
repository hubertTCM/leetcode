using System;
using System.Collections.Generic;
namespace BinarySearch
{
    public static class BinarySearchExtension
    {
        // return the first index which source[index] >= target
        public static int UpperBound(this int[] source, int target)
        {
            if (source.Length == 0)
            {
                return -1;
            }
            var ans = -1;
            var left = 0; var right = source.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (source[mid] == target)
                {
                    return mid;
                }
                if (source[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    ans = mid;
                    right = mid - 1;
                }
            }
            return ans;
        }

        // max index with source[index]<= target
        public static int LowerBound(this int[] source, int target)
        {
            if (source.Length == 0)
            {
                return -1;
            }
            var ans = -1;
            var left = 0;
            var right = source.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (source[mid] == target)
                {
                    return mid;
                }
                if (source[mid] < target)
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return ans;
        }
    }

    public class Test
    {
        static Random _r = new Random();

        public static void Run()
        {
            for (var len = 1; len <= 10000; len++)
            {
                var source = RandomArray(len);
                // existing value: 
                var index = _r.Next(0, len - 1);
                VerifyUpperBound(source, source[index], index);
                VerifyLowerBound(source, source[index], index);

                // not exist
                VerifyUpperBound(source, source[len - 1] + 100, -1);
                VerifyLowerBound(source, source[0] - 10, -1);

                // some random check:
                for (var i = 0; i < Math.Min(len, 1000); i++)
                {
                    var targetIndex = i;
                    var expectIndex = targetIndex < len - 1 ? targetIndex + 1 : -1;
                    VerifyUpperBound(source, source[targetIndex] + 1, expectIndex);
                    VerifyLowerBound(source, source[targetIndex] + 1, targetIndex);
                }
            }
        }

        static void VerifyUpperBound(int[] source, int target, int expectIndex)
        {
            // var slow = UpperBound(source, target);
            // if (expectIndex != slow)
            // {
            //     Console.WriteLine($"Fialed: source: [{string.Join(",", source)}] target:{target}  expect:{expectIndex} actual:{slow}");
            // }

            var actual = source.UpperBound(target);
            if (expectIndex != actual)
            {
                Console.WriteLine($"Fialed: source: [{string.Join(",", source)}] target:{target}  expect:{expectIndex} actual:{actual}");
                throw new Exception("verify failed");
            }
        }

        static void VerifyLowerBound(int[] source, int target, int expectIndex)
        {
            // var slow = UpperBound(source, target);
            // if (expectIndex != slow)
            // {
            //     Console.WriteLine($"Fialed: source: [{string.Join(",", source)}] target:{target}  expect:{expectIndex} actual:{slow}");
            // }

            var actual = source.LowerBound(target);
            if (expectIndex != actual)
            {
                Console.WriteLine($"Fialed: source: [{string.Join(",", source)}] target:{target}  expect:{expectIndex} actual:{actual}");
                throw new Exception("verify failed");
            }
        }

        static int[] RandomArray(int len)
        {
            var start = _r.Next(0, 30);
            var source = new int[len];
            for (var i = 0; i < len; i++)
            {
                var next = start + _r.Next(2, 10);
                source[i] = next;
                start = next;
            }
            return source;
        }

        static int UpperBound(int[] source, int target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] >= target)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}