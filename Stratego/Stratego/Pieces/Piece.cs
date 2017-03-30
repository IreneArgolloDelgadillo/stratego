using Stratego.Playrules.Attack;
using Stratego.Playrules.Move;
using System.Collections.Generic;

namespace Stratego
{
    public abstract class Piece
    {
        
        public Piece(List<IMovementRule> movementRules, List<IAttackRule> attackRules, Gamer owner, int rank, int maximum)
        {
            this.movementRules = movementRules;
            this.attackRules = attackRules;
            this.owner = owner;
            this.rank = rank;
            maximumQuantity = maximum;
        }

        public AttackResult Attack(Piece attacked)
        {
            AttackResult attack = AttackResult.NoAttack;
            attackRules.ForEach(rule =>
            {
                attack = rule.AcceptCriterion(this, attacked);
            });

            return (!attack.Equals(AttackResult.NoAttack))? attack : AttackResult.Lose;
        }

        public bool MoveAt(Square current, Square nextStep, Dictionary<Square, Piece> boardSpace)
        {
            bool result = true;
            movementRules.ForEach(rule =>
            {
                result = result && (rule.AcceptCriterion(current, nextStep, boardSpace));
            });
            return result;
        }

        public override bool Equals(object obj)
        {
            Piece piece = obj as Piece;
            return obj.GetType() == GetType() && piece.owner.Equals(owner);
        }

        public override int GetHashCode()
        {
            return rank.GetHashCode();
        }

        public Gamer Owner { get { return owner; } }

        public int Rank { get { return rank; } }

        public int MaximumQuantity { get { return maximumQuantity; } }

        public List<IMovementRule> MovementRules { get { return movementRules; } }

        private Gamer owner;
        private int maximumQuantity;
        private int rank;
        private List<IAttackRule> attackRules;
        private List<IMovementRule> movementRules;
    }
}
