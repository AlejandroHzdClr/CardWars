using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Actions;

public class PlayCardAction : IGameAction
{
    private readonly CardMain card;

    public PlayCardAction(CardMain card)
    {
        this.card = card;
    }

    public bool CanExecute(GameContext context)
    {
        return card.CurrentZone == card.Owner.Hand
               && context.Turns.CanPlay(card)
               && card.Owner.Field.CardCount < 5;
    }

    public void Execute(GameContext context)
    {
        context.MoveCard(card, card.Owner.Field);

        ExecuteOnPlayEffects(context);
    }

    private void ExecuteOnPlayEffects(GameContext context)
    {
        foreach (var effect in card.Effects)
        {
            effect.Execute(card, card, context);
        }
    }
}