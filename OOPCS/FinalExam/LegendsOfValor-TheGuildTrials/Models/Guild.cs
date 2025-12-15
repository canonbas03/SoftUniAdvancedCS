using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string name;
        private int wealth;
        private readonly List<string> legion;
        public Guild(string name)
        {
            Name = name;
            wealth = 5000;
            IsFallen = false;
            legion = new List<string>();
        }
        public string Name
        {
            get => name;

            private set
            {
                if (value != "WarriorGuild" &&
                    value != "SorcererGuild" &&
                    value != "ShadowGuild")
                {
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                }

                name = value;
            }
        }

        public int Wealth
        {
            get => wealth;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                wealth = value;
            }
        }

        public IReadOnlyCollection<string> Legion
        {
            get => legion.AsReadOnly();
        }

        public bool IsFallen { get; private set; }

        public void LoseWar()
        {
            IsFallen = true;
            Wealth = 0;
        }

        public void RecruitHero(IHero hero)
        {
            int cost = 500;
            this.Wealth -= cost;

            this.legion.Add(hero.RuneMark);
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            int cost = 200;
            foreach(IHero hero in heroesToTrain)
            {
                Wealth -= cost;
                hero.Train();
            }
        }

        public void WinWar(int goldAmount)
        {
            Wealth += goldAmount;
        }
    }
}
