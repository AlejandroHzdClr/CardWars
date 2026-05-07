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

    public CardEvents EventType { get; set; }

    public int EventValue { get; set; }

    public Side Owner { get; set; }

    public bool State { get; set; }

    public event Action<CardMain, CardMain, CardEvents, int> EventAction;

    protected void RaiseAction(CardMain target, CardEvents type, int value)
    {
        EventAction?.Invoke(this, target, type, value);
    }

    public void Activate(CardMain target)
    {
        RaiseAction(target, EventType, EventValue);
    }
}