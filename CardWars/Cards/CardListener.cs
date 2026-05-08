using System.Diagnostics;

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
        card.EventAction += OnCardEvent;
    }
    
    public void OnCardEvent(CardMain target, CardEvents type, int value1)
    {
        switch (type)
        {
            case CardEvents.Ko:
                if (target.Cost <= value1)
                {
                    MoveToGraveyard(target);
                    RemoveCard(target);
                }
                break;
            case CardEvents.Rest:
                if (target.State)
                {
                    target.State = false;
                }
                else
                {
                    Console.WriteLine("La Carta ya esta resteada");
                }
                break;
            case CardEvents.Return:
                if (target.Cost <= value1)
                {
                    MoveToHand(target);
                    RemoveCard(target);
                }

                break;
            case CardEvents.ReduceCost:
                if (target.Cost <= value1)
                {
                    target.Cost -= 1;
                }
                break;
            case CardEvents.ReduceDamage:
                // if (target.Damage <= 1000)
                // {
                //     target.Damage = 0;
                // }
                // else
                // {
                //     target.Damage -= 1000;
                // }
                target.Damage -= 1000;
                Console.WriteLine("He bajado daño");

                break;
            case CardEvents.IncreaseDamage:
                target.Damage += 1000;
                break;
            default:
                break;
                
        }
    }

    private void MoveToGraveyard(CardMain target)
    {
        if (target.Owner == Side.Player)
        {
            Game.PlayerZones.Graveyard.Add(target);
        }
        else
        {
            Game.EnemyZones.Graveyard.Add(target);
        }
    }

    private void MoveToHand(CardMain target)
    {
        if (target.Owner == Side.Player)
        {
            Game.PlayerZones.Hand.Add(target);
        }
        else
        {
            Game.EnemyZones.Hand.Add(target);
        }
    }
    
    private void RemoveCard(CardMain card)
    {
        if (card.Owner == Side.Player)
        {
            Game.PlayerZones.Field.Remove(card);
        }
        else
        {
            Game.EnemyZones.Field.Remove(card);
        }
    }
}