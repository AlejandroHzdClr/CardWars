using CardWars.Cards;

namespace CardWars.EffectTypes.EnergyEffect;

public class DecreaseCost : Effect
{
    private int DCost;
    public DecreaseCost(Card objetive, int decrease) : base(objetive)
    {
        DCost = decrease;
    }

    public void ReduceCost()
    {
        if (!(Objetive.Cost <= 1))
        {
            Objetive.Cost -= DCost;
        }
    }
}