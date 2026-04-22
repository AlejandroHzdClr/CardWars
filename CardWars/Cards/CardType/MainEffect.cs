namespace CardWars.Cards.CardType;

public class MainEffect : Card
{
    protected MainEffect(int damage, int cost, int counter) : base(damage, cost, counter)
    {
        this.Effect = CardTypes.MainEffect;
    }
}