
using System;
using System.Collections.Generic;
using System.Linq;
namespace P221
{
    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            var heights = new int[matrix[0].Length];
            var ans = 0;
            for (var row = 0; row < matrix.Length; row++)
            {
                var stack = new Stack<int>();
                var maxHeight = row + 1;

                for (var col = 0; col < matrix[row].Length && ans < maxHeight * maxHeight; col++)
                {
                    heights[col] = matrix[row][col] == '0' ? 0 : heights[col] + 1;

                    // keep the stack increase, so the previous item in stack is the most left item lower than mine
                    while (stack.Count > 0 && heights[stack.Peek()] > heights[col])
                    {
                        var height = Math.Min(heights[stack.Pop()], maxHeight);
                        var left = stack.Count == 0 ? 0 : stack.Peek() + 1;
                        var right = col - 1;
                        var width = right - left + 1;
                        var length = Math.Min(width, height);
                        ans = Math.Max(ans, length * length);
                        if (ans == maxHeight * maxHeight)
                        {
                            break;
                        }
                    }
                    stack.Push(col);
                }

                while (ans < maxHeight * maxHeight && stack.Count > 0)
                {
                    var height = Math.Min(heights[stack.Pop()], maxHeight);
                    var left = stack.Count == 0 ? 0 : stack.Peek() + 1;
                    var right = matrix[row].Length - 1;
                    var width = right - left + 1;
                    var length = Math.Min(width, height);
                    ans = Math.Max(ans, length * length);
                }
            }
            return ans;
        }
    }

    public class Test
    {
        public static void Run()
        {

            /*

            [["1","1","1","0","0"],["1","1","1","0","0"],["1","1","1","1","1"],["0","1","1","1","1"],["0","1","1","1","1"],["0","1","1","1","1"]]
            Expect: 16

            */

            var s = new Solution();
            // [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
            var matrix = new string[4][];
            matrix[0] = new string[] { "1", "0", "1", "0", "0" };
            matrix[1] = new string[] { "1", "0", "1", "1", "1" };
            matrix[2] = new string[] { "1", "1", "1", "1", "1" };
            matrix[3] = new string[] { "1", "0", "0", "1", "0" };
            var charInput = new char[4][];
            for (var i = 0; i < matrix.Length; i++)
            {
                charInput[i] = new char[matrix[i].Length];
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    charInput[i][j] = matrix[i][j].ToCharArray()[0];
                }
            }
            s.MaximalSquare(charInput);
            Console.WriteLine("");
        }
    }
}
