using CardWars.Actions;
using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;
using CardWars.Zones;

namespace CardWars.GameManager;

public class GameLogic
{
    public GameContext Context;

    public CardMain HoveredCard { get; private set; }
    
    public Queue<IGameAction> ActionQueue = new();

    private SelectionManager selection = new();

    public GameLogic(GameContext context)
    {
        Context = context;
    }

    public void Update()
    {
        Console.WriteLine("Update running");

        // 🔥 MOTOR DEL JUEGO: ejecutar acciones
        ResolveActions();
    }

    // -------------------------------------------------
    // 🔥 ACTION SYSTEM
    // -------------------------------------------------
    private void ResolveActions()
    {
        while (ActionQueue.Count > 0)
        {
            var action = ActionQueue.Dequeue();

            if (action.CanExecute(Context))
            {
                action.Execute(Context);
            }
        }
    }

    // -------------------------------------------------
    // 🔥 API DEL MOTOR (SIN MOUSE)
    // -------------------------------------------------

    public void PlayCard(CardMain card)
    {
        ActionQueue.Enqueue(new PlayCardAction(card));
    }

    public void Attack(CardMain source, CardMain target)
    {
        selection.Source = source;
        selection.Target = target;

        ActionQueue.Enqueue(new AttackAction(source, target));
        selection.Reset();
    }

    public void EndTurn()
    {
        ActionQueue.Enqueue(new EndTurnAction());
    }
    
    public void SetHoveredCard(CardMain card)
    {
        HoveredCard = card;
    }
}