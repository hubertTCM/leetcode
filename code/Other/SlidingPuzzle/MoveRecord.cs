using System;
namespace SlidingPuzzle
{
    public class MoveRecord
    {
        Position _from;
        Position _to;
        int _value;

        public MoveRecord(Position from, Position to, int value)
        {
            _from = from;
            _to = to;
            _value = value;
        }
    }
}