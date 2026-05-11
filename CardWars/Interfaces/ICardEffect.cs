using CardWars.Cards;

namespace CardWars.Interfaces;

public interface ICardEffect
{
    void Execute(CardMain target, GameManager.GameManager game);
    
    string GetDescription();
}