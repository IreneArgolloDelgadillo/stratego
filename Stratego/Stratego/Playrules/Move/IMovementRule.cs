using System.Collections.Generic;

namespace Stratego.Playrules.Move
{
    public interface IMovementRule
    {
            bool AcceptCriterion(Square current, Square next, Dictionary<Square, Piece> boardSpace);
    }
}
