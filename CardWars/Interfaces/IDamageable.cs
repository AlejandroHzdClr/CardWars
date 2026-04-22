namespace CardWars.Interfaces;

public interface IDamageable
{
    int Damage { get; }
    
    void TakeDamage(IDamageable damage);

    void GetKo();
}