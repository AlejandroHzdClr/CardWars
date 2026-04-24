using CardWars.Cards;

namespace CardWars.Interfaces;

public interface IPlayer
{
    void GetCards(int cardNumber, Player.Player playerHand);
}