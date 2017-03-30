using Stratego.Playrules.Move;
using System.Collections.Generic;

namespace Stratego
{
    public class ManyStepByStep : IMovementRule
    {
        public bool AcceptCriterion(Square current, Square next, Dictionary<Square, Piece> boardSpace)
        {
            bool constantInX = (current.X - next.X == 0);
            if (constantInX || (current.Y - next.Y == 0))
            {
                int constantAxis;
                int initial;
                int end;
                if (constantInX)
                {
                    constantAxis = current.X;
                    initial = current.Y;
                    end = next.Y;
                }
                else
                {
                    constantAxis = current.Y;
                    initial = current.X;
                    end = next.X;
                }
                return AreTherePlayers(constantAxis, initial, end, constantInX, boardSpace);
            }
            return false;
        }

        private bool AreTherePlayers(int constantAxis, int initial, int end, bool constantInX, Dictionary<Square, Piece> boardSpace)
        {
            bool result = true;
            for (int i = initial + 1; i <= end; i++)
            {
                Square square = constantInX ? new Square(constantAxis, i) : new Square(i, constantAxis);
                result = result && boardSpace[square] == null;
            }
            return result;
        }
    }
}
