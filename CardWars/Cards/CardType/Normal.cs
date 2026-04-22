namespace CardWars.Cards.CardType;

public class Normal : Card
{
    protected Normal(int damage, int cost, int counter) : base(damage, cost, counter)
    {
        this.Effect = CardTypes.Normal;
    }
}