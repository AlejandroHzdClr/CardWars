using CardWars.Cards;
using CardWars.Interfaces;
namespace CardWars.Player;

public class Player : IPlayer, IDamageable
{
    
    public int Lifes { get; private set; }
    public int Damage { get; private set; }
    public string Name { get; }
    public Deck PlayerDeck { get; private set; }
    public Hand PlayerHand { get; private set; }

    public Player(string name, int lifes, int damage, Deck playerDeck, Hand playerHand)
    {
        Name = name;
        Lifes = lifes;
        Damage = damage;
        PlayerDeck = playerDeck;
        PlayerHand = playerHand;
    }
    
    public void GetCards(int number, Player player)
    {
        PlayerDeck.GiveCards(number,player);
    }

    public void TakeDamage(IDamageable damageable)
    {
        throw new NotImplementedException();
    }

    public void GetKo()
    {
        throw new NotImplementedException();
    }
}