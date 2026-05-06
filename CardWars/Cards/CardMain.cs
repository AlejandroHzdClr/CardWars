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
    public String Name;
    public int Damage;
    public int Cost;
    public Side Owner;
    public bool State;
    public event Action<CardMain, CardMain, CardEvents, int> EventAction;

    public event Action<List<CardMain>, CardEvents, int> AreaEventAction;
    
    protected void RaiseAction(CardMain target,CardEvents type, int damageCap)
    {
        EventAction?.Invoke(this, target , type, damageCap);
    }
    
    protected void RaiseAreaAction(List<CardMain> targets, CardEvents type, int damage)
    {
        AreaEventAction?.Invoke(targets, type, damage);
    }
}