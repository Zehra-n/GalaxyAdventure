namespace AdventureGalaxy;

public interface IDamageable
{
    void TakeDamage(int damage);
    bool IsDestroyed { get; }
}