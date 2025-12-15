using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private List<IGuild> guilds = new List<IGuild>();

        public void AddModel(IGuild entity)
        {
            guilds.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return guilds.AsReadOnly();
        }

        public IGuild GetModel(string guildName)
        {
            return guilds.FirstOrDefault(g => g.Name == guildName);
        }
    }
}
