namespace CardWars.Cards.CardType;

public class OnPlay : Card
{
    protected OnPlay(string name,int damage, int cost, int counter) : base( name, damage, cost, counter)
    {
        this.Effect = CardTypes.OnPlay;
    }
}