using CardWars.Cards;

namespace CardWars.EffectTypes.CostEffect;

public class DecreaseCost : Effect
{
    private int decreaseCost;
    public DecreaseCost(Card objetive, int decrease) : base(objetive)
    {
        decreaseCost = decrease;
    }

    public void ApplyDecrease()
    {
        Objetive.Damage -= decreaseCost;
    }
}