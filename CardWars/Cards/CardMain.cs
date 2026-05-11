using CardWars.Interfaces;

namespace CardWars.Cards;

public enum CardEvents
{
    Ko,
    Return,
    Rest,
    ReduceCost,
    ReduceDamage,
    IncreaseDamage
}

public enum Side
{
    Player,
    Enemy
}

public class CardMain
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Damage { get; set; }

    public int Cost { get; set; }

    public Side Owner { get; set; }

    public bool State { get; set; }
    
    public bool CanAttack { get; set; }
    
    public List<ICardEffect> Effects { get; set; } = new();

    public event Action<CardMain, ICardEffect>? EventAction;

    public void RaiseAction(CardMain target)
    {
        foreach (ICardEffect cardEffect in Effects)
        {
            EventAction?.Invoke(target, cardEffect);
        }
        
    }
}