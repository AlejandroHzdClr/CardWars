using CardWars.Effects;

namespace CardWars.Cards;

public class CardData
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Damage { get; set; }

    public int Cost { get; set; }

    public List<EffectData> Effects { get; set; } = new();
}