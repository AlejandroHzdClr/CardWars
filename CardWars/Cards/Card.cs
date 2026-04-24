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
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Cost { get; set; }
    public CardTypes Effect { get; set; }
    public int Counter { get; set; }
    public bool State { get; set; }

    public Card(string name,int damage, int cost, int counter)
    {
        this.Name = name;
        this.Damage = damage;
        this.Cost = cost;
        this.Counter = counter;
        this.State = true;
    }

    public virtual void BeingDeployed(List<Card> cardList)
    {
        cardList.Add(this);
    }

    public virtual void OnAttack(IDamageable damageable)
    {
        Console.WriteLine(this.Name + " ha intentado atacar");
        if (Damage >= damageable.Damage)
        {
            damageable.TakeDamage(damageable);
            Console.WriteLine(damageable.Name + " ha recibido el daño");
        }
    }

    public void TakeDamage(IDamageable damageable)
    {
        if (damageable.Damage >= Damage)
        {
            GetKo();
        }
    }

    public int GettingCounter(Card card)
    {
        return Damage + card.Counter;
    }

    public virtual void GetKo()
    {
        
    }
}