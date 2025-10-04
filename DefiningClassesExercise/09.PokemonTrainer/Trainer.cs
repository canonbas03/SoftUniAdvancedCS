using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    internal class Trainer
    {
        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
        }

        public void ReduceHealth()
        {
            for (int i = Pokemons.Count - 1; i >= 0; i--)
            {
                Pokemons[i].Health -= 10;
                if (Pokemons[i].Health <= 0)
                    Pokemons.RemoveAt(i);
            }
        }
    }
}