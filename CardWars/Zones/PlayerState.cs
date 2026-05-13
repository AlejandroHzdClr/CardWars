using CardWars.Zones;

namespace CardWars.Core;

public class PlayerState
{
    public Hand Hand { get; } = new Hand();
    public Field Field { get; } = new Field();
    public Graveyard Graveyard { get; } = new Graveyard();
}