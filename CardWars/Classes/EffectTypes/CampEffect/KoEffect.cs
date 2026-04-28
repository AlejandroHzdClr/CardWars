using CardWars.Classes.Cards;

namespace CardWars.Classes.EffectTypes.CampEffect;

public class KoEffect : Effect
{
    public int damageCap;
    public KoEffect(Card objetive,int cap) : base(objetive)
    {
        damageCap = cap;
    }

    public void CompareDamage()
    {
        if (damageCap >= Objetive.Damage)
        {
            Objetive.GetKo();
        }
    }
}