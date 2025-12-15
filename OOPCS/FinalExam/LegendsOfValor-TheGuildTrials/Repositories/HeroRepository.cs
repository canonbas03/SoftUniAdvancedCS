using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes = new List<IHero>();
        public void AddModel(IHero entity)
        {
            heroes.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return heroes.AsReadOnly();
        }

        public IHero GetModel(string runeMark)
        {
            // Check if guildname should be included as well
            return heroes.FirstOrDefault(h => h.RuneMark == runeMark);
        }
    }
}
