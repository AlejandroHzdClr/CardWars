namespace CardWars.Cards;

public class Deck
{
    public List<Card> CardDeck { get; private set; }

    public Deck(List<Card> deck)
    {
        this.CardDeck = deck;
    }
}