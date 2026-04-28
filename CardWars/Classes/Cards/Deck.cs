namespace CardWars.Classes.Cards;

public class Deck
{
    public List<Card> CardDeck { get; private set; }
    public Random rng = new Random();

    public Deck(List<Card> deck)
    {
        this.CardDeck = deck;
    }

    public void Shuffle()
    {
        int n = CardDeck.Count();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (CardDeck[k], CardDeck[n]) = (CardDeck[n], CardDeck[k]); 
        }
    }

    public void GiveCards(int numberOfCards, Player.Player player)
    {
        if (player.PlayerDeck.CardDeck.Count >= numberOfCards)
        {
            player.PlayerHand.CardsHand.Add(player.PlayerDeck.CardDeck[0]);
            player.PlayerDeck.CardDeck.RemoveAt(0);
        }
    }

    public void ShowCards()
    {
        foreach (Card card in CardDeck)
        {
            Console.WriteLine("Carta: " + card.Name + " Daño: " + card.Damage + " Efecto: " + card.Effect
            + " Counter: " + card.Counter + " Coste: " + card.Cost);
        }
    }
}