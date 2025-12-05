using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        private const double DefaultRanking = 60;
        private const double RankingModifier = 1.5;
        public ProfessionalManager(string name) : base(name, DefaultRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue * RankingModifier;
        }
    }
}
