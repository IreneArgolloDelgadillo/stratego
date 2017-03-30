using Stratego.Pieces;

namespace Stratego.Playrules.Attack
{
    public class StrategicAttackRule : IAttackRule
    {
        public AttackResult AcceptCriterion(Piece attacker, Piece attacked)
        {
            if ((attacker is Marshal || attacked is Marshal) && (attacker is Spy || attacked is Spy))
                return AttackResult.Win;
            else
                return AttackResult.NoAttack;
        }
    }
}
