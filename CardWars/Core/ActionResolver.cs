using CardWars.Interfaces;

namespace CardWars.Core;

public class ActionResolver
{
    public void Resolve(GameContext context, IGameAction action)
    {
        context.State = GameState.ResolvingAction;

        try
        {
            if (action.CanExecute(context))
            {
                action.Execute(context);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            context.State = GameState.WaitingInput;
        }
    }
}