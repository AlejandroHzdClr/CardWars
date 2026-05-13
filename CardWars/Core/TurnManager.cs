using CardWars.Cards;
using CardWars.Zones;

namespace CardWars.Core;

public class TurnManager
{
    private readonly PlayerState player1;
    private readonly PlayerState player2;

    public PlayerState CurrentPlayer { get; private set; }

    public TurnPhase CurrentPhase { get; private set; }
        = TurnPhase.Draw;

    public int TurnNumber { get; private set; } = 1;

    public TurnManager(PlayerState p1, PlayerState p2)
    {
        player1 = p1;
        player2 = p2;

        CurrentPlayer = player1;
    }

    public void NextPhase()
    {
        switch (CurrentPhase)
        {
            case TurnPhase.Draw:
                CurrentPhase = TurnPhase.Main;
                break;

            case TurnPhase.Main:
                CurrentPhase = TurnPhase.Combat;
                break;

            case TurnPhase.Combat:
                CurrentPhase = TurnPhase.End;
                break;

            case TurnPhase.End:
                EndTurn();
                break;
        }
    }

    private void EndTurn()
    {
        CurrentPlayer =
            CurrentPlayer == player1
                ? player2
                : player1;

        CurrentPhase = TurnPhase.Draw;

        TurnNumber++;
    }

    public bool CanPlay(CardMain card)
    {
        return card.Owner == CurrentPlayer
               && CurrentPhase == TurnPhase.Main;
    }

    public bool CanAttack(CardMain card)
    {
        return card.Owner == CurrentPlayer
               && CurrentPhase == TurnPhase.Combat
               && card.CanAttack;
    }
}