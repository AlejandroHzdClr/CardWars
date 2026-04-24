using CardWars.Cards;

namespace CardWars.EffectTypes;

public class Effect
{
    public Card Objetive { get; protected set; }

    public Effect(Card objetive)
    {
        Objetive = objetive;
    }
    
}