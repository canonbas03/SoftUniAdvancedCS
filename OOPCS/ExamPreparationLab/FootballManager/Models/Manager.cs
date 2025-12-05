using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private const double minRanking = 0;
        private const double maxRanking = 100;

        private double ranking;
        protected Manager(string name, double ranking)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.ManagerNameNull);
            Name = name;
            Ranking = ranking;
        }

        public string Name { get; }

        public double Ranking
        {
            get => this.ranking;

            protected set
            {
                if (value < minRanking) ranking = minRanking;
                else if (value > maxRanking) ranking = maxRanking;
                else ranking = value;
            }
        }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString()
            => $"{Name} - {this.GetType().Name} (Ranking: {Ranking:F2})";
    }
}
