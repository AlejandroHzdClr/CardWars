using CardWars.Cards;
using CardWars.Core;
using CardWars.Effects;
using CardWars.Zones;

public static class CardFactory
{
    public static CardMain Create(CardData data, PlayerState owner, IZone initialZone)
    {
        CardMain card = new()
        {
            Id = data.Id,
            Name = data.Name,
            Damage = data.Damage,
            Cost = data.Cost,
            Owner = owner,
            CurrentZone = initialZone
        };

        foreach (var effectData in data.Effects)
        {
            var effect = EffectFactory.Create(effectData);
            card.Effects.Add(effect);
        }

        return card;
    }
}