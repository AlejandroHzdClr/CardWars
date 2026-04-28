namespace CardWars.Classes.Interfaces;

public interface IDamageable
{
    int Damage { get; }
    string Name { get; }
    
    void TakeDamage(IDamageable damage);

    void GetKo();
}