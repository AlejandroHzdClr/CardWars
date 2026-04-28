using CardWars.Classes.Cards;

namespace CardWars.Classes.EffectTypes.DamageEffect;

public class DecreaseDamage : Effect
{
    private int decreaseNumber;
    public DecreaseDamage(Card objetive, int decrease) : base(objetive)
    {
        decreaseNumber = decrease;
    }

    public void ApplyDecrease()
    {
        Objetive.Damage -= decreaseNumber;
    }
}