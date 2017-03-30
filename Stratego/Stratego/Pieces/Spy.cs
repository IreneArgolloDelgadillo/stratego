using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Pieces
{
    public class Spy : Piece
    {

        public Spy(Gamer owner): base (movementRules, attackRules, owner, rank, maximum)
        {

        }

        private static List<IMovementRule> movementRules = new List<IMovementRule> { new OccupiedSquare(), new StepByStep() };
        private static List<IAttackRule> attackRules = new List<IAttackRule> { new RankRule(), new StrategicAttackRule() };
        private static int rank = 1;
        private static int maximum = 1;
    }
}
