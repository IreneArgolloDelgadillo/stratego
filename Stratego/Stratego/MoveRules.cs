using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public abstract class MoveRule : IPlayRule<Square>
    {
        private List<Square> lakesPosition;

        public MoveRule()
        {
            lakesPosition = new List<Square>();
            Piece piece = new Piece(PieceType.Lake);
            lakesPosition.Add(new Square(3, 5, piece));
            lakesPosition.Add(new Square(4, 5, piece));
            lakesPosition.Add(new Square(7, 5, piece));
            lakesPosition.Add(new Square(8, 5, piece));

            lakesPosition.Add(new Square(3, 6, piece));
            lakesPosition.Add(new Square(4, 6, piece));
            lakesPosition.Add(new Square(7, 6, piece));
            lakesPosition.Add(new Square(8, 6, piece));
        }

        public  bool acceptCriterion(Square value, Square other)
        {
            return !lakesPosition.Contains(other) | other.Piece != null;
        }

    }
}
