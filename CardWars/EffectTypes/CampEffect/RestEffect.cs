using CardWars.Cards;

namespace CardWars.EffectTypes.CampEffect;

public class RestEffect : Effect
{
    private int Cost;
    public RestEffect(Card objetive, int cost) : base(objetive)
    {
        Cost = cost;
    }

    public void RestObjective()
    {
        if (Cost >= Objetive.Cost)
        {
            Objetive.State = false;
        }
    }
}