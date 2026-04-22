using CardWars.Cards;
using CardWars.Interfaces;
namespace CardWars.Player;

public class Player : IPlayer, IDamageable
{
    private int lifes;
    private Deck deck;
    
    
    
    public void GetCards()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new NotImplementedException();
    }
}