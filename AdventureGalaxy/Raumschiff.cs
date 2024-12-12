namespace AdventureGalaxy;

public class Raumschiff
{
    public string Name { get; }
    public int Gesundheit { get; private set; }
    public int Energie { get; private set; }
    public int Angriffskraft { get; private set; }
    public List<string> Ressourcen { get; }

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
        Gesundheit = 100;
        Console.WriteLine($"{Name} wurde repariert.");
    }

    public void Angriff(Alien alien)
    {
        Console.WriteLine($"{Name} greift {alien.Name} an!");
        alien.SchadenNehmen(Angriffskraft);
    }

    public void Energieverbrauchen(int menge)
    {
        Energie -= menge;
        if (Energie < 0) Energie = 0;
        Console.WriteLine($"{Name} hat jetzt {Energie} Energie.");
    }

    public override string ToString()
    {
        return $"Raumschiff: {Name}, Gesundheit: {Gesundheit}, Energie: {Energie}, Angriffskraft: {Angriffskraft}";
    }
}