using CardWars.Classes.Cards;

namespace CardWars.Classes.EffectTypes;

public class Effect
{
    public Card Objetive { get; protected set; }

    public Effect(Card objetive)
    {
        Objetive = objetive;
    }
    
}