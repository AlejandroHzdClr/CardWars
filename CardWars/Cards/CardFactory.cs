namespace CardWars.Cards;

public static class CardFactory
{
    public static CardMain Create(CardData data)
    {
        return new CardMain
        {
            Id = data.Id,
            Name = data.Name,
            Damage = data.Damage,
            Cost = data.Cost,
            EventType = data.EventType,
            EventValue = data.EventValue
        };
    }
}