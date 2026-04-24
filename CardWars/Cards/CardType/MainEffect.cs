namespace CardWars.Cards.CardType;

public class MainEffect : Card
{
    protected MainEffect(string name,int damage, int cost, int counter) : base( name, damage, cost, counter)
    {
        this.Effect = CardTypes.MainEffect;
    }
}