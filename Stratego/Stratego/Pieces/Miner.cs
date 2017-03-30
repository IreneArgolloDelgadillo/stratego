using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Pieces
{
    public class Miner : Piece
    {

        public Miner(Gamer owner): base (movementRules, attackRules, owner, rank, maximum)
        {

        }

        private static List<IMovementRule> movementRules = new List<IMovementRule> { new OccupiedSquare(), new StepByStep() };
        private static List<IAttackRule> attackRules = new List<IAttackRule> { new RankRule(), new ExplotionRule() };
        private static int rank = 3;
        private static int maximum = 5;
    }
}
