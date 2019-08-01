namespace Battleships.Models
{
    public class Point
    {
        public int Column { get; }
        public int Row { get; }
        public bool IsShot { get; private set; }

        public Point(int column, int row)
        {
            Column = column;
            Row = row;
        }
        
        public void Shoot(int column, int row)
        {
            if (Column == column && Row == row) IsShot = true;
        }

        public bool Equals(Point obj)
        {
            return Column == obj.Column && Row == obj.Row;
        }
    }
}
