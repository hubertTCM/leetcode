
using System;
using System.Collections.Generic;
using System.Linq;
using Util;
namespace P1776
{
    public class Solution
    {
        public double[] GetCollisionTimes(int[][] cars)
        {
            var ans = new double[cars.Length];
            var stack = new Stack<int>();
            for (var i = cars.Length - 1; i >= 0; i--)
            {
                ans[i] = -1;
                var currentSpeed = cars[i][1];
                var currentPosition = cars[i][0];
                while (stack.Count > 0)
                {
                    if (currentSpeed <= cars[stack.Peek()][1])
                    {
                        stack.Pop();
                        continue;
                    }
                    var top = cars[stack.Peek()];
                    var collisionTime = (top[0] - currentPosition) * 1.0 / (currentSpeed - top[1]);
                    if (ans[stack.Peek()] < 0 || collisionTime < ans[stack.Peek()])
                    {
                        ans[i] = collisionTime;
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                stack.Push(i);
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(string.Join(",", s.GetCollisionTimes(new int[,] { { 1, 2 }, { 2, 1 }, { 4, 3 }, { 7, 2 } }.ToJaggedArray()))); // [1.00000,-1.00000,3.00000,-1.00000]
            Console.WriteLine(string.Join(",", s.GetCollisionTimes(new int[,] { { 3, 4 }, { 5, 4 }, { 6, 3 }, { 9, 1 } }.ToJaggedArray()))); // [2.00000,1.00000,1.50000,-1.00000]
        }
    }
}
