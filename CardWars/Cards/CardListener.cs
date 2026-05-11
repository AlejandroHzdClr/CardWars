using System.Diagnostics;
using CardWars.Interfaces;

namespace CardWars.Cards;

public class CardListener
{
    public GameManager.GameManager Game;

    public CardListener(GameManager.GameManager game)
    {
        Game = game;
    }

    public void Listener(CardMain card)
    {
        card.EventAction += EventAction;
    }

    private void EventAction(CardMain card, ICardEffect effect)
    {
        effect.Execute(card, Game);
    }
    
    // private void MoveToGraveyard(CardMain target)
    // {
    //     if (target.Owner == Side.Player)
    //     {
    //         Game.PlayerZones.Graveyard.Add(target);
    //     }
    //     else
    //     {
    //         Game.EnemyZones.Graveyard.Add(target);
    //     }
    // }
    //
    // private void MoveToHand(CardMain target)
    // {
    //     if (target.Owner == Side.Player)
    //     {
    //         Game.PlayerZones.Hand.Add(target);
    //     }
    //     else
    //     {
    //         Game.EnemyZones.Hand.Add(target);
    //     }
    // }
    //
    // private void RemoveCard(CardMain card)
    // {
    //     if (card.Owner == Side.Player)
    //     {
    //         Game.PlayerZones.Field.Remove(card);
    //     }
    //     else
    //     {
    //         Game.EnemyZones.Field.Remove(card);
    //     }
    // }
}