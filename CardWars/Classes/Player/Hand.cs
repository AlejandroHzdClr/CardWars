using CardWars.Classes.Cards;

namespace CardWars.Classes.Player;

public class Hand
{
    public List<Card> CardsHand { get; private set; } = new List<Card>();

    public Hand(List<Card> lista)
    {
        CardsHand = lista;
    }
}