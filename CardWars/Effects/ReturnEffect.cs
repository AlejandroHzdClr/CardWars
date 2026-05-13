using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class ReturnEffect : ICardEffect
{

    private int _count;

    public ReturnEffect(int count)
    {
        _count = count;
    }
    
    public void Execute(CardMain source, CardMain target, GameContext game)
    {
        game.MoveCard(target, target.Owner.Hand);
    }

    public string GetDescription()
    {
        return $"Return a <= {_count}";
    }
}