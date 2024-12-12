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
                    new Alien("Eiskrieger", true, 60, 20)
                ),
                new Planet(
                    "Omega-7",
                    "Ein Handelsplanet mit freundlichen Aliens.",
                    new List<string> { "Gold", "Seltene Erden" },
                    new Alien("Händler von Omega", true, 60, 30)
                )
            };
        }
        public void Start()
        {
            Console.WriteLine("Willkommen bei Galaxy Adventures!");
            Console.WriteLine($"Dein Schiff, {schiff.Name}, startet die Erkundung der Galaxie.");

            schiff.Move();

            foreach (var planet in galaxie)
            {
                planet.Erkunden(schiff);

                if (planet.Bewohner is IAttackable alien && alien.IsDestroyed == false)
                {
                    Kampf(alien);
                }
                
                if (schiff.IsDestroyed)
                {
                    Console.WriteLine("Dein Raumschiff wurde zerstört. Spiel vorbei!");
                    return;
                }

                if (schiff.Gesundheit < 100)
                {
                    Console.WriteLine("Möchtest du dein Raumschiff reparieren? (j/n)");
                    var eingabe = Console.ReadLine();
                    if (eingabe?.ToLower() == "j")
                    {
                        schiff.Reparieren();
                    }
                }
            }
            Console.WriteLine("Du hast die Galaxie erfolgreich erkundet!");
        }

        
        private void Kampf(IAttackable gegner)
        {
            while (!gegner.IsDestroyed && !schiff.IsDestroyed)
            {
                schiff.Attack(gegner);
                if (!gegner.IsDestroyed)
                {
                    gegner.Attack(schiff);
                }
            }
            
            if (schiff.IsDestroyed)
            {
                Console.WriteLine("Dein Raumschiff wurde zerstört!");
            }
            else
            {
                Console.WriteLine($"Der Gegner wurde besiegt!");
            }
        }
    }

