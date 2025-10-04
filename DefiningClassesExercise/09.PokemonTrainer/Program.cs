using System.Reflection.Metadata;

namespace _09.PokemonTrainer
{
    internal class Program
    {
        public static Dictionary<string, Trainer> trainersByName = new Dictionary<string, Trainer>();
        static void Main(string[] args)
        {
            CreatePokemons();
            Tournament();

            foreach(Trainer trainer in trainersByName.Values.OrderByDescending(t => t.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }

        }

        public static void CreatePokemons()
        {
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainersByName.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainersByName[trainerName] = trainer;
                }
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainersByName[trainerName].Pokemons.Add(pokemon);
            }
        }

        public static void Tournament()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainersByName.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                        trainer.BadgesCount++;
                    else
                        trainer.ReduceHealth();
                }
            }
        }
    }
}

/*
Sam Blastoise Water 18
Narry Pikachu Electricity 22
John Kadabra Psychic 90
Tournament
Fire
Electricity
Fire
End
 */