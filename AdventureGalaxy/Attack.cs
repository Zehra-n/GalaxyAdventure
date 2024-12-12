namespace AdventureGalaxy;

public interface IAttackable
{
    void Attack(IAttackable target);
    void TakeDamage(int damage);
    bool IsDestroyed { get; }
}

