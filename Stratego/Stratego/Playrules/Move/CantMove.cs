using Stratego.Playrules.Move;
using System.Collections.Generic;

namespace Stratego
{
    public class CantMove : IMovementRule
    {
        public bool AcceptCriterion(Square current, Square criterion, Dictionary<Square, Piece> boardSpace)
        {
            return false;
        }
    }
}
