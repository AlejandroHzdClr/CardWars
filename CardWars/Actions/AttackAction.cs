using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;
using CardWars.Zones;

namespace CardWars.Actions;

public class AttackAction : IGameAction
{
    private readonly CardMain attacker;
    private readonly CardMain target;

    public AttackAction(CardMain attacker, CardMain target)
    {
        this.attacker = attacker;
        this.target = target;
    }

    public bool CanExecute(GameContext context)
    {
        if (context.Turns.CurrentPhase != TurnPhase.Combat)
            return false;

        if (attacker.Owner != context.Turns.CurrentPlayer)
            return false;

        if (attacker == target)
            return false;

        if (!attacker.CanAttack)
            return false;

        if (target.Owner == attacker.Owner)
            return false;

        if (attacker.CurrentZone.Type != ZoneType.Field)
            return false;

        if (target.CurrentZone.Type != ZoneType.Field)
            return false;

        return true;
    }

    public void Execute(GameContext context)
    {
        bool isDead = target.TakeDamage(attacker.Damage);

        attacker.CanAttack = false;

        if (isDead)
        {
            context.MoveCard(
                target,
                target.Owner.Graveyard
            );
        }
    }
}