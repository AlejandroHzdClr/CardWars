namespace CardWars.Cards.CardType;

public class Normal : Card
{
    protected Normal(string name,int damage, int cost, int counter) : base( name, damage, cost, counter)
    {
        this.Effect = CardTypes.Normal;
    }
}