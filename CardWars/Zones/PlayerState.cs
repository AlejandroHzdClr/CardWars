using CardWars.Zones;

namespace CardWars.Core;

public class PlayerState
{
    public Deck Deck { get; } = new Deck();   // FIX: añadido Deck que faltaba
    public Hand Hand { get; } = new Hand();
    public Field Field { get; } = new Field();
    public Graveyard Graveyard { get; } = new Graveyard();
}
