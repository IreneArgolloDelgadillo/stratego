﻿using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Pieces
{
    public class Coronel : Piece
    {
        public Coronel(Gamer owner): base (movementRules, attackRules, owner, rank, maximum)
        {

        }

        private static List<IMovementRule> movementRules = new List<IMovementRule> { new OccupiedSquare(), new StepByStep() };
        private static List<IAttackRule> attackRules = new List<IAttackRule> { new RankRule() };
        private static int rank = 8;
        private static int maximum = 2;
    }
}
