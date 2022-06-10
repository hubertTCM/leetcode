using System;
using System.Linq;

namespace SlidingPuzzle
{
    public class Board
    {
        int[,] _board;
        public Board(int n, int m)
        {
            _board = new int[n, m];
            Init();
        }

        public int GetValue(Position position)
        {
            return _board[position.Row, position.Column];
        }

        public int RowCount
        {
            get; private set;
        }

        public int ColumnCount
        {
            get; private set;
        }

        public Position BlankPosition
        {
            get; private set;
        }

        public MoveRecord Move(Position from)
        {
            if (from.Row < 0 || from.Row >= RowCount ||
                 from.Column < 0 || from.Column >= ColumnCount){
                throw new InvalidOperationException($"Invalid position. [{from.Row}, {from.Column}]");
            }
            var neighbors = from.Neighbors;
            var valid = Array.IndexOf(from.Neighbors, BlankPosition) >= 0;
            if (!valid)
            {
                throw new InvalidOperationException($"Cannot move item from Position [{from.Row}, {from.Column}] to [{BlankPosition.Row}, {BlankPosition.Column}]");
            }
            var value = GetValue(from);
            SetValue(BlankPosition, value);
            var result = new MoveRecord(from, BlankPosition, value);
            BlankPosition = from;
            return result;
        }

        void SetValue(Position position, int value)
        {
            _board[position.Row, position.Column] = value;
        }

        void Init()
        {
            RowCount = _board.GetLength(0);
            ColumnCount = _board.GetLength(1);
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; i++)
                {
                    _board[i, j] = i * ColumnCount + j + 1;
                }
            }
            _board[RowCount - 1, ColumnCount - 1] = 0;
            BlankPosition = new Position(RowCount - 1, ColumnCount - 1);
        }

    }
}