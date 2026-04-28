using CardWars.Classes.Cards;

namespace CardWars.Classes.EffectTypes.DamageEffect;

public class IncreaseDamage : Effect
{
    private int increaseNumber;
    public IncreaseDamage(Card objetive, int increase) : base(objetive)
    {
        increaseNumber = increase;
    }

    public void ApplyIncrease()
    {
        Objetive.Damage += increaseNumber;
    }
}