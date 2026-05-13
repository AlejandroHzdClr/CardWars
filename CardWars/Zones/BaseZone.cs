using CardWars.Cards;

namespace CardWars.Zones;

public abstract class BaseZone : IZone
{
    protected List<CardMain> cards = new();

    public IReadOnlyList<CardMain> Cards => cards;

    public int CardCount => cards.Count;

    public abstract ZoneType Type { get; }

    public virtual bool Contains(CardMain card)
    {
        return cards.Contains(card);
    }

    public virtual bool CanAdd(CardMain card)
    {
        return true;
    }

    public virtual void Add(CardMain card)
    {
        cards.Add(card);
    }

    public virtual void Remove(CardMain card)
    {
        cards.Remove(card);
    }
}