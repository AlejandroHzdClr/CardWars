namespace CardWars.Cards.CardType;

public class OnKo : Card
{
    protected OnKo(int damage, int cost, int counter) : base(damage, cost, counter)
    {
        this.Effect = CardTypes.OnOk;
    }
}