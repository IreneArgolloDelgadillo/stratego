using Stratego.Pieces;
using Stratego.Playrules.Move;
using System.Collections.Generic;

namespace Stratego
{
    public class OccupiedSquare : IMovementRule
    {
        public  bool AcceptCriterion(Square current, Square next, Dictionary<Square, Piece> boardSpace)
        {
            return boardSpace[next] == null && boardSpace[current] != null; 
        }

        private static Piece lake = new Lake();
    }
}
