using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Effects;

public class ReduceDamageEffect : ICardEffect
{
    private int _amount;

    public ReduceDamageEffect(int amount)
    {
        _amount = amount;
    }
    
    public void Execute(CardMain target, GameManager.GameManager game)
    {
        if (target.Damage >= _amount)
        {
            target.Damage -= _amount;
        }
    }

    public string GetDescription()
    {
        return $"Reduce  {_amount} Damage";
    }
}