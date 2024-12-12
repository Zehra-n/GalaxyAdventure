namespace AdventureGalaxy;

public class Spiel
{
    private readonly Raumschiff schiff;
    private readonly List<Planet> galaxie;

    public Spiel()
    {
        schiff = new Raumschiff("Stellar Voyager", 100, 100, 20);
        galaxie = new List<Planet>
        {
            new Planet(
                "Zeta-1",
                "Ein fruchtbarer Planet voller grüner Täler.",
                new List<string> { "Wasser", "Mineralien" },
                null
            ),
            new Planet(
                "Kryon",
                "Ein gefrorener Planet voller Geheimnisse.",
                new List<string>(),
                new Alien("Eiskrieger", true, 50, 10)
            ),
            new Planet(
                "Omega-7",
                "Ein Handelsplanet mit freundlichen Aliens.",
                new List<string> { "Gold", "Seltene Erden" },
                new Alien("Händler von Omega", false, 30, 0)
            )
        };
    }

    public void Start()
    {
        Console.WriteLine("Wilkommen bei Galaxy Adventures!");
        Console.WriteLine($"Dein Schiff, {schiff.Name}, startet die Erkundung der Galaxie.");

        foreach (var planet in galaxie)
        {
            planet.Erkunden(schiff);
            
            if (planet.Bewohner != null && planet.Bewohner.IstFeindlich)
            {
                Kampf(planet.Bewohner);
            }
            if (schiff.Gesundheit <= 0)
            {
                Console.WriteLine("Dein Raumschiff wurde zerstört. Spiel vorbei!");
                return;
            }
        }
        Console.WriteLine("Du hast die Galaxie erfolgreich erkundet!");
    }

    private void Kampf(Alien alien)
    {
        while (alien.Gesundheit > 0 && schiff.Gesundheit > 0)
        {
            schiff.Angriff(alien);
            if (alien.Gesundheit > 0)
            {
                alien.Angriff(schiff);
            }
        }

        if (schiff.Gesundheit <= 0)
        {
            Console.WriteLine("DeinRaumschiff wurde zerstört!");
        }
        else
        {
            Console.WriteLine($"{alien.Name} wurde besiegt!");
        }
    }
}