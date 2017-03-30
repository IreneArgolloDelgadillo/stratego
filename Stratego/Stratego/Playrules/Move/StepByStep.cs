using Stratego.Playrules.Move;
using System;
using System.Collections.Generic;

namespace Stratego
{
    public class StepByStep : IMovementRule
    {
        public bool AcceptCriterion(Square current, Square next, Dictionary<Square, Piece> boardSpace) 
        {
            int currentX = current.X;
            int currentY = current.Y;

            return (Math.Abs(currentX - next.X) == 1 && currentY == next.Y) ||
                (Math.Abs(currentY - next.Y) == 1 && currentX == next.X);
        }
    }
}
