using CardWars.Interfaces;

namespace CardWars.Cards;

public enum CardTypes
{
    Normal = 0,
    OnPlay = 1,
    MainEffect = 2,
    OnOk = 3,
    WhenAttack = 4
}


public class Card : IDamageable
{
    public int Damage { get; protected set; }
    public int Cost { get; protected set; }
    public CardTypes Effect { get; protected set; }
    public int Counter { get; protected set; }
    public bool State { get; protected set; }

    protected Card(int damage, int cost, int counter)
    {
        this.Damage = damage;
        this.Cost = cost;
        this.Counter = counter;
        this.State = true;
    }

    public virtual void BeingDeployed(List<Card> cardList)
    {
        cardList.Add(this);
    }

    public virtual void OnAttack()
    {
        
    }

    public void TakeDamage()
    {
        throw new NotImplementedException();
    }
}