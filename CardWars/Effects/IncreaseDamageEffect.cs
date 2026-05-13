using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class IncreaseDamageEffect : ICardEffect
{
    public void Execute(CardMain source, CardMain target, GameContext game)
    {
        target.Damage += 1000;
    }

    public string GetDescription()
    {
        return "Increase 1000 Damage";
    }
}