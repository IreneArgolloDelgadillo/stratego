﻿using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Pieces
{
    public class Flag : Piece
    {
        public Flag(Gamer owner): base (movementRules, attackRules, owner, rank, maximum)
        {

        }

        private static List<IMovementRule> movementRules = new List<IMovementRule> { new CantMove() };
        private static List<IAttackRule> attackRules = new List<IAttackRule> { new RankRule() };
        private static int rank = 0;
        private static int maximum = 1;
    }
}
