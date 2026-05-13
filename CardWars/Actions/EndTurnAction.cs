using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Actions;

public class EndTurnAction : IGameAction
{
    public bool CanExecute(GameContext context)
    {
        return context.State == GameState.WaitingInput;
    }

    public void Execute(GameContext context)
    {
        context.Turns.NextPhase();
    }
}