using CardWars.Cards;
using CardWars.Effects;

public static class CardFactory
{
    public static CardMain Create(CardData data)
    {
        CardMain card = new()
        {
            Id = data.Id,
            Name = data.Name,
            Damage = data.Damage,
            Cost = data.Cost,
        };

        foreach (var effectData in data.Effects)
        {
            card.Effects.Add(
                EffectFactory.Create(effectData)
            );
        }

        return card;
    }
}