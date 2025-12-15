using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        private const int START_POWER = 50;
        private const int START_MANA = 60;
        private const int START_STAMINA = 60;
        public Spellblade(string name, string runeMark)
            : base(name, runeMark, START_POWER, START_MANA, START_STAMINA)
        {
        }

        public override void Train()
        {
            this.Power += 15;
            this.Mana += 10;
            this.Stamina += 10;
        }
    }
}
