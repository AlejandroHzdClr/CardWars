using CardWars.Cards;
using CardWars.Zones;

public interface IZone
{
    ZoneType Type { get; }

    IReadOnlyList<CardMain> Cards { get; }

    int CardCount { get; }

    bool Contains(CardMain card);

    bool CanAdd(CardMain card);

    void Add(CardMain card);

    void Remove(CardMain card);
}