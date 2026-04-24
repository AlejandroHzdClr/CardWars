using CardWars.Cards;
using CardWars.Player;

namespace CardWars.EffectTypes.CampEffect;

public class ReturnEffect : Effect
{
    private Hand Hand;
    private int Cost;
    public ReturnEffect(Card objetive, Hand hand, int cost) : base(objetive)
    {
        Hand = hand;
        Cost = cost;
    }

    public void ReturnCard()
    {
        if (Cost <= Objetive.Cost)
        {
            Hand.CardsHand.Add(Objetive);
        }
    }
}