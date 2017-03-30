using Stratego.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Playrules.Attack
{
    public class ExplotionRule : IAttackRule
    {
        public AttackResult AcceptCriterion(Piece attacker, Piece attacked)
        {
            return (attacked is Bomb) ? AttackResult.Win : AttackResult.Lose;
        }
    }
}
