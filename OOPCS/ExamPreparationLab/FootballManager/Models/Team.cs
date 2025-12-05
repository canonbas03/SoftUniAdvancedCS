using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            Name = name;
        }
        public string Name { get; }

        public int ChampionshipPoints { get; private set; }

        public IManager TeamManager { get; private set; }

        public int PresentCondition
        {
            get
            {
                if (TeamManager is null) return 0;

                double result;
                if (ChampionshipPoints == 0) result = TeamManager.Ranking;
                else result = ChampionshipPoints * TeamManager.Ranking;

                return (int)Math.Floor(result);
            }
        }

        public void GainPoints(int points)
        {
            this.ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            this.ChampionshipPoints = 0;
        }

        public void SignWith(IManager manager)
        {
            this.TeamManager = manager;
        }

        public override string ToString()
            => $"Team: {Name} Points: {ChampionshipPoints}";
    }
}
