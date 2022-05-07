using System;
namespace SlidingPuzzle
{
    public class MoveCommand
    {
        Position _from;
        Position _to;
        Board _board;
        int _value;

        public MoveCommand(Board board, Position from, Position to)
        {
            _board = board;
            _from = from;
            _to = to;
        }

        public void Do()
        {
            _value = _board.GetValue(_from);
            if (_board.GetValue(_to) != 0)
            {
                throw new InvalidOperationException();
            }

            _board.SetValue(_from, 0);
            _board.SetValue(_to, _value);
        }

        public void Undo()
        {
            if (_board.GetValue(_from) != 0 || _board.GetValue(_to) != _value)
            {
                throw new InvalidOperationException();
            }

            _board.SetValue(_to, 0);
            _board.SetValue(_from, _value);
        }
    }
}