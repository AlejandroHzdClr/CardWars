using CardWars.Core;
using CardWars.Cards;

namespace CardWars.Interfaces;

public interface ICardEffect
{
    void Execute(CardMain source, CardMain target, GameContext context);

    string GetDescription();
}