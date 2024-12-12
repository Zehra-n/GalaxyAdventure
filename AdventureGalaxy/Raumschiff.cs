using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdventureGalaxy;

public class Raumschiff : IMovable, IAttackable, IDamageable
{
    public string Name { get; }
    public int Gesundheit { get; private set; }
    public int Energie { get; private set; }
    public int Angriffskraft { get; private set; }
    public List<string> Ressourcen { get; }
    
    private const int MaxGesundheit = 100;

    public bool IsDestroyed => Gesundheit <= 0;

    public Raumschiff(string name, int gesundheit, int energie, int angriffskraft)
    {
        Name = name;
        Gesundheit = gesundheit;
        Energie = energie;
        Angriffskraft = angriffskraft;
        Ressourcen = new List<string>();
    }

    public void Reparieren()
    {
        if (Gesundheit == MaxGesundheit)
        {
            Console.WriteLine($"{Name} ist bereits in einwandfreiem Zustand.");
            return;
        }

        int reparaturKosten = 25;
        int heilungsBetrag = 5;

        if (Energie >= reparaturKosten)
        {
            Energie -= reparaturKosten;
            Gesundheit += heilungsBetrag;
            if (Gesundheit > MaxGesundheit)
            {
                Gesundheit = MaxGesundheit;
            }
            Console.WriteLine($"{Name} wurde um {heilungsBetrag} Punkte repariert. Gesundheit: {Gesundheit}, Energie: {Energie}");
        }
        else
        {
            Console.WriteLine($"{Name} hat nicht genug {Energie} für eine Reparatur.");
        }
    }

    public void Move()
    {
        Console.WriteLine($"{Name} fliegt durch die Galaxie.");
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
        return $"Raumschiff: {Name}, Gesundheit: {Gesundheit}, Energie: {Energie}, Angriffskraft: {Angriffskraft}";
    }
}
