using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class RestEffect : ICardEffect
{
    private int _count;

    public RestEffect(int count)
    {
        _count = count;
    }
    
    public void Execute(CardMain target, GameManager.GameManager game)
    {
        if (target.State && target.Cost >= _count)
        {
            target.State = false;
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