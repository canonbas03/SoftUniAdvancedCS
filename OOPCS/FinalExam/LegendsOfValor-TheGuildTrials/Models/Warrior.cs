using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        private const int START_POWER = 60;
        private const int START_MANA = 0;
        private const int START_STAMINA = 100;
        public Warrior(string name, string runeMark) 
            : base(name, runeMark, START_POWER, START_MANA, START_STAMINA)
        {
        }

        public override void Train()
        {
            this.Power += 30;
            this.Stamina += 10;
        }
    }
}
