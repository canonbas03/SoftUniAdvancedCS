using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            Name = name;
        }

        public override string Name { get; }

        public override int Power => 100;

        public override string CastAbility() 
            => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
