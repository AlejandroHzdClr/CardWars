using CardWars.Core;
using CardWars.Interfaces;
using CardWars.Zones;

namespace CardWars.Cards;

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

    public Side OwnerSide { get; set; }

    public PlayerState Owner { get; set; }

    public bool CanAttack { get; set; } = true;

    public IZone CurrentZone { get; set; }

    public List<ICardEffect> Effects { get; set; } = new();

    public bool TakeDamage(int amount)
    {
        return amount >= Damage;
    }
}