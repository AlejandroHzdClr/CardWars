using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class KoEffect : ICardEffect
{
    private int _cost;
    
    public KoEffect(int cost)
    {
        _cost = cost;
    }
    
    public void Execute(CardMain source, CardMain target, GameContext game)
    {
        if (target.Cost <= _cost)
        {
            game.MoveCard(target, target.Owner.Graveyard);
        }
    }

    public string GetDescription()
    {

        return $"Execute cost <= {_cost}";
    }
}