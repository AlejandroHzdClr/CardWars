namespace CardWars.Classes.Cards.CardType;

public class WhenAttacking : Card
{
    protected WhenAttacking(string name,int damage, int cost, int counter) : base( name, damage, cost, counter)
    {
        this.Effect = CardTypes.WhenAttack;
    }
}