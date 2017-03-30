using Stratego.Pieces;
using Stratego.Playrules.Attack;

namespace Stratego
{
    public class RankRule : IAttackRule
    {
        public AttackResult AcceptCriterion(Piece attacker, Piece attacked)
        {
            if (attacked.Equals(new Lake()))
            {
                return AttackResult.NoAttack;
            }
            else if (attacker.Rank > attacked.Rank)
            {
                return AttackResult.Win;
            }
            else if (attacker.Rank < attacked.Rank)
            {
                return AttackResult.Lose;
            }
            else
            {
                return AttackResult.Draw;
            }
        }
    }
}
