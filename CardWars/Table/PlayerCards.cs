using CardWars.Cards;

namespace CardWars.Table;

public class PlayerCards
{
    protected List<Card> CardOnTable { get; private set; } = new List<Card>();
}