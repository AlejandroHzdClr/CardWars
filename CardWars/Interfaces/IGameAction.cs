using CardWars.Core;

namespace CardWars.Interfaces;

public interface IGameAction
{
    bool CanExecute(GameContext context);
    void Execute(GameContext context);
}