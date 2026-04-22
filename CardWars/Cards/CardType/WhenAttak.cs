namespace CardWars.Cards.CardType;

public class WhenAttacking : Card
{
    protected WhenAttacking(int damage, int cost, int counter) : base(damage, cost, counter)
    {
        this.Effect = CardTypes.WhenAttack;
    }
}