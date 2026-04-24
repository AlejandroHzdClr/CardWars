using CardWars.Cards;

namespace CardWars.Table;

public class PlayerCards
{
    public List<Card> CardOnTable { get; private set; } = new List<Card>();
}