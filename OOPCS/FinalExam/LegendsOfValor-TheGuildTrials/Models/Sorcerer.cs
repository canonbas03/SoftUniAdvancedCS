using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        private const int START_POWER = 40;
        private const int START_MANA = 120;
        private const int START_STAMINA = 0;
        public Sorcerer(string name, string runeMark)
            : base(name, runeMark, START_POWER, START_MANA, START_STAMINA)
        {
        }

        public override void Train()
        {
            this.Power += 20;
            this.Mana += 25;
        }
    }
}
