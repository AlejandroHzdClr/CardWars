namespace CardWars.Classes.Cards.CardType;

public class OnKo : Card
{
    protected OnKo(string name,int damage, int cost, int counter) : base( name, damage, cost, counter)
    {
        this.Effect = CardTypes.OnOk;
    }
}