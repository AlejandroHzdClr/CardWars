using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class RestEffect : ICardEffect
{
    private int _count;

    public RestEffect(int count)
    {
        _count = count;
    }
    
    public void Execute(CardMain source, CardMain target, GameContext game)
    {
        if (target.CanAttack && target.Cost >= _count)
        {
            target.CanAttack = false;
        }
        else
        {
            Console.WriteLine("Ya está resteado");
        }
    }

    public string GetDescription()
    {
        return $"Rest <= {_count} cost";
    }
}