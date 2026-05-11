using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class ReturnEffect : ICardEffect
{

    private int _count;

    public ReturnEffect(int count)
    {
        _count = count;
    }
    
    public void Execute(CardMain target, GameManager.GameManager game)
    {
        if (target.Owner == Side.Player)
        {
            game.PlayerZones.Hand.Add(target);
            game.PlayerZones.Field.Remove(target);
        }
        else
        {
            game.EnemyZones.Hand.Add(target);
            game.EnemyZones.Field.Remove(target);
        }
    }

    public string GetDescription()
    {
        return $"Return a <= {_count}";
    }
}