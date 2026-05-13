using CardWars.Cards;

namespace CardWars.Zones;

public class Field : BaseZone
{
    public override ZoneType Type => ZoneType.Field;

    public int MaxSlots => 5;

    public override bool CanAdd(CardMain card)
    {
        return CardCount < MaxSlots;
    }
}