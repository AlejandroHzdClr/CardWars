using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class EffectResolver
{
    public void Resolve(CardMain source, CardMain target, ICardEffect effect, GameContext context)
    {
        effect.Execute(source, target, context);
    }
}