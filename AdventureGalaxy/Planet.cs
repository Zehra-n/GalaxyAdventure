namespace AdventureGalaxy;

public class Planet : IMovable
{
    public string Name { get; }
    public string Beschreibung { get; }
    public List<string> Ressourcen { get; }
    public Alien? Bewohner { get; }

    public Planet(string name, string beschreibung, List<string> ressourcen, Alien? bewohner)
    {
        Name = name;
        Beschreibung = beschreibung;
        Ressourcen = ressourcen;
        Bewohner = bewohner;
    }
    public void Move()
    {
        Console.WriteLine($"Der Planet {Name} bewegt sich in seiner Umlaufbahn.");
    }
    
    public void Erkunden(Raumschiff schiff)
    {
        Console.WriteLine($"Du landest auf dem Planeten {Name}: {Beschreibung}");

        if (Bewohner != null)
        {
            if (Bewohner.IstFeindlich)
            {
                Console.WriteLine($"Ein feindlicher Alien namens {Bewohner.Name} greift an!");
            }
            else
            {
                Console.WriteLine($"Ein freundlicher Alien namens {Bewohner.Name} bietet dir Handel an.");
            }
        }
        else
        {
            Console.WriteLine("Der Planet ist unbewohnt.");
        }

        if (Ressourcen.Count > 0)
        {
            Console.WriteLine($"Du findest Ressourcen: {string.Join(", ", Ressourcen)}");
            schiff.Ressourcen.AddRange(Ressourcen);
        }
    }
}
