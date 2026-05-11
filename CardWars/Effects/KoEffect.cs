using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class KoEffect : ICardEffect
{
    private int _cost;
    
    public KoEffect(int cost)
    {
        _cost = cost;
    }
    
    public void Execute(CardMain target, GameManager.GameManager game)
    {
        if (target.Cost <= _cost)
        {
            if (target.Owner == Side.Player)
            {
                game.PlayerZones.Graveyard.Add(target);
                game.PlayerZones.Field.Remove(target);
            }
            else
            {
                game.EnemyZones.Graveyard.Add(target);
                game.EnemyZones.Field.Remove(target);
            }
        }
    }

    public string GetDescription()
    {

        return $"Execute cost <= {_cost}";
    }
}