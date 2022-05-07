using System;
using System.Collections.Generic;

namespace SlidingPuzzle
{
    public class Solution
    {
        int[,] _board;
        public List<int> Run(int n, int m, int start, int end)
        {
            _board = new int[n, m];
            var result = new List<int>();
            return result;
        }

        void Init()
        {
            var rowCount = _board.GetLength(0);
            var columnCount = _board.GetLength(1);
            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; i++)
                {
                    _board[i, j] = i * rowCount + j + 1;
                }
            }
            _board[rowCount - 1, columnCount - 1] = 0;
        }
    }
}