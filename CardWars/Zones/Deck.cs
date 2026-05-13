using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Zones;

public class Deck : BaseZone, ICardCollection // FIX: faltaba declarar ICardCollection
{
    private Random rng = new();

    public override ZoneType Type => ZoneType.Deck;

    public void Shuffle()
    {
        int n = cards.Count;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (cards[k], cards[n]) = (cards[n], cards[k]);
        }
    }

    public CardMain Draw()
    {
        if (cards.Count == 0)
            return null;

        CardMain top = cards[0];
        cards.RemoveAt(0);
        return top;
    }
}
