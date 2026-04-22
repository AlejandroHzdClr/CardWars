namespace CardWars.Cards.CardType;

public class OnPlay : Card
{
    protected OnPlay(int damage, int cost, int counter) : base(damage, cost, counter)
    {
        this.Effect = CardTypes.OnPlay;
    }
}