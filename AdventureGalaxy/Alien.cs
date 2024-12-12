namespace AdventureGalaxy;

public class Alien
{
    public string Name { get; }
    public bool IstFeindlich { get; }
    public int Gesundheit { get; private set; }
    public int Angriffskraft { get; }

    public Alien(string name, bool istFeindlich, int gesundheit, int angriffskraft)
    {
        Name = name;
        IstFeindlich = istFeindlich;
        Gesundheit = gesundheit;
        Angriffskraft = angriffskraft;
    }

    public void SchadenNehmen(int schaden)
    {
        Gesundheit -= schaden;
        if (Gesundheit < 0) Gesundheit = 0;
        Console.WriteLine($"{Name} hat {Gesundheit} Gesundheit übrig.");
    }

    public void Angriff(Raumschiff schiff)
    {
        Console.WriteLine($"{Name} greift {schiff.Name} an!");
    }

    public override string ToString()
    {
        return $"Alien: {Name}, Feindlich: {IstFeindlich}, Gesundheit: {Gesundheit}, Angriffskraft: {Angriffskraft}";
    }
}
    
