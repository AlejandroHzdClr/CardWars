using CardWars.Cards;

namespace CardWars.EffectTypes.CampEffect;

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