using Stratego.Playrules.Move;

namespace Stratego
{
    public class Square
    {
        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } }

        public int Y { get { return y; } }

        public override bool Equals(object obj)
        {
            Square Square = obj as Square;
            return this.x == Square.x && this.y == Square.y;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode();
        }

        private int x;
        private int y;
    }
}
