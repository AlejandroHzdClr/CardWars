using CardWars.Cards;
using CardWars.Interfaces;
namespace CardWars.Player;

public class Player : IPlayer, IDamageable
{
    public int Lifes { get; private set; }
    public int Damage { get; private set; }
    private Deck deck;
    
    
    
    public void GetCards()
    {
        throw new NotImplementedException();
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