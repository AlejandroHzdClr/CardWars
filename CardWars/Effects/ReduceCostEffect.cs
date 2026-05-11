using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class ReduceCostEffect : ICardEffect
{
   
    
    public void Execute(CardMain target, GameManager.GameManager game)
    {
        if (target.Cost >= 1)
        {
            target.Cost -= 1;
        }
        else
        {
            Console.WriteLine("Ya tiene coste muy bajo");
        }
    }

    public string GetDescription()
    {
        return "Reduce 1 cost";
    }
}