using CardWars.Interfaces;

namespace CardWars.Effects;

public class EffectFactory
{
    public static ICardEffect Create(EffectData data)
    {
        return data.Type switch
        {
            "KoEffect" => new KoEffect(data.MaxCost),
                
            "ReduceDamageEffect" => 
                new ReduceDamageEffect(data.Amount),
            
            "IncreaseDamageEffect" => 
                new IncreaseDamageEffect(),
            
            "RestEffect" => 
                new RestEffect(data.Amount),
            
            "ReduceCostEffect" => 
                new ReduceCostEffect(),
            
            "ReturnEffect" => 
                new ReturnEffect(data.Amount),

            _ => throw new Exception($"Effect {data.Type} not found")
        };
    }
}