namespace SlidingPuzzle
{
    public struct Position
    {
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; }
        public int Column { get; }

        public Position[] Neighbors
        {
            get
            {
                var result = new Position[4];
                // up
                result[0] = new Position(Row - 1, Column);
                // down
                result[1] = new Position(Row + 1, Column);
                // left
                result[2] = new Position(Row, Column - 1);
                // right
                result[3] = new Position(Row, Column + 1);
                return result;
            }
        }
    }
}