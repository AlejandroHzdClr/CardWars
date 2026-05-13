using CardWars.Cards;
using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class ReturnEffect : ICardEffect
{
    private int _count;

    public ReturnEffect(int count)
    {
        _count = count;
    }

    public void Execute(CardMain source, CardMain target, GameContext game)
    {
        // FIX: solo devuelve la carta a mano si su coste es <= _count
        // Antes devolvía siempre sin filtrar, ignorando _count por completo
        if (target.Cost <= _count)
        {
            game.MoveCard(target, target.Owner.Hand);
        }
    }

    public string GetDescription()
    {
        return $"Return cost <= {_count} to hand";
    }
}
