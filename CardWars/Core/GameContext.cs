using CardWars.Cards;
using CardWars.Zones;

namespace CardWars.Core;

public class GameContext
{
    public PlayerState Player1 { get; }
    public PlayerState Player2 { get; }

    public TurnManager Turns { get; }

    public GameState State { get; set; } = GameState.WaitingInput;

    public GameContext(PlayerState p1, PlayerState p2)
    {
        Player1 = p1;
        Player2 = p2;

        Turns = new TurnManager(p1, p2);
    }

    public void MoveCard(CardMain card, IZone destination)
    {
        IZone source = FindZone(card);

        if (source != null)
        {
            source.Remove(card);
        }

        destination.Add(card);

        card.CurrentZone = destination;
    }

    private IZone FindZone(CardMain card)
    {
        if (Player1.Hand.Contains(card)) return Player1.Hand;
        if (Player1.Field.Contains(card)) return Player1.Field;
        if (Player1.Graveyard.Contains(card)) return Player1.Graveyard;

        if (Player2.Hand.Contains(card)) return Player2.Hand;
        if (Player2.Field.Contains(card)) return Player2.Field;
        if (Player2.Graveyard.Contains(card)) return Player2.Graveyard;

        return null;
    }
}