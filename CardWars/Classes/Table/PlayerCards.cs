using CardWars.Classes.Cards;

namespace CardWars.Classes.Table;

public class PlayerCards
{
    public List<Card> CardOnTable { get; private set; } = new List<Card>();
}