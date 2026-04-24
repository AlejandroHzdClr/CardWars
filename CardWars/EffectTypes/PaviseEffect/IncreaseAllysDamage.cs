using CardWars.Cards;
using CardWars.Table;

namespace CardWars.EffectTypes.PaviseEffect;

public class IncreaseAllysDamage
{
    private PlayerCards playerCards;
    private int Damage;

    public IncreaseAllysDamage(PlayerCards pCards, int damage)
    {
        playerCards = pCards;
        Damage = damage;
    }

    public void ApplyPassive()
    {
        foreach (Card card in playerCards.CardOnTable)
        {
            card.Damage += Damage;
        }
    }
}