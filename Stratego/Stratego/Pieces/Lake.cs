using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System.Collections.Generic;

namespace Stratego.Pieces
{
    public class Lake : Piece
    {
        
        public Lake(): base (movementRules, attackRules, owner, rank, 0)
        {

        }

        private static List<IMovementRule> movementRules = new List<IMovementRule> { new CantMove() };
        private static List<IAttackRule> attackRules = new List<IAttackRule> { new RankRule() };
        private static Gamer owner = new Gamer("Game");
        private static int rank = 12;
    }
}
