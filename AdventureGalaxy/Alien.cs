namespace AdventureGalaxy;

public class Alien : IAttackable, IDamageable
{
    public string Name { get; }
    public bool IstFeindlich { get; }
    public int Gesundheit { get; private set; }
    public int Angriffskraft { get; }

    public bool IsDestroyed => Gesundheit <= 0;

    public Alien(string name, bool istFeindlich, int gesundheit, int angriffskraft)
    {
        Name = name;
        IstFeindlich = istFeindlich;
        Gesundheit = gesundheit;
        Angriffskraft = angriffskraft;
    }

    public void Attack(IAttackable target)
    {
        Console.WriteLine($"{Name} greift {target} an!");
        target.TakeDamage(Angriffskraft);
    }

    public void TakeDamage(int damage)
    {
        Gesundheit -= damage;
        if (Gesundheit < 0) Gesundheit = 0;
        Console.WriteLine($"{Name} hat {Gesundheit} Gesundheit übrig.");
    }

    public override string ToString()
    {
        return $"Alien: {Name}, Feindlich: {IstFeindlich}, Gesundheit: {Gesundheit}, Angriffskraft: {Angriffskraft}";
    }
}

