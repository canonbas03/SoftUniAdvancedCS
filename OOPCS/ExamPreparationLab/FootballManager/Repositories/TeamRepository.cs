using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private const int DefaultCapacity = 10;

        private readonly List<ITeam> teams;
        public TeamRepository()
        {
            teams = new List<ITeam>();
            this.Models = teams.AsReadOnly();
        }
        public IReadOnlyCollection<ITeam> Models { get; }

        public int Capacity => DefaultCapacity;

        public void Add(ITeam model)
        {
            if (teams.Count < 10) teams.Add(model);
        }

        public bool Exists(string name)
        {
            return this.teams.Any(t => t.Name == name);
        }

        public ITeam Get(string name)
        {
            return this.teams.FirstOrDefault(t => t.Name == name);
        }

        public bool Remove(string name)
        {
            return this.teams.RemoveAll(x => x.Name == name) > 0;
        }
    }
}
