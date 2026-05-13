using CardWars.Actions;
using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;
using CardWars.Zones;

namespace CardWars.GameManager;

public class GameLogic
{
    public GameContext Context;

    public CardMain HoveredCard  { get; private set; }
    public CardMain SelectedCard { get; private set; } // FIX: expuesto para renderer e input

    public Queue<IGameAction> ActionQueue = new();

    private SelectionManager selection = new();

    public GameLogic(GameContext context)
    {
        Context = context;
    }

    public void Update()
    {
        ResolveActions();
    }

    private void ResolveActions()
    {
        while (ActionQueue.Count > 0)
        {
            var action = ActionQueue.Dequeue();
            if (action.CanExecute(Context))
                action.Execute(Context);
        }
    }

    // -------------------------------------------------
    // API DEL MOTOR
    // -------------------------------------------------

    public void PlayCard(CardMain card)
    {
        ActionQueue.Enqueue(new PlayCardAction(card));
        SelectedCard = null;
    }

    public void Attack(CardMain source, CardMain target)
    {
        selection.Source = source;
        selection.Target = target;
        ActionQueue.Enqueue(new AttackAction(source, target));
        selection.Reset();
        SelectedCard = null;
    }

    public void EndTurn()
    {
        ActionQueue.Enqueue(new EndTurnAction());
        SelectedCard = null;
    }

    public void SetHoveredCard(CardMain card)  => HoveredCard  = card;
    public void SetSelectedCard(CardMain card) => SelectedCard = card;
}
