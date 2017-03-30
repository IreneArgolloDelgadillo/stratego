
namespace Stratego.Playrules.Attack
{
    public interface IAttackRule 
    {
        AttackResult AcceptCriterion(Piece value, Piece other);
    }
}
