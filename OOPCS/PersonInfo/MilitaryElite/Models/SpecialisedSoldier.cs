using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : RegularSoldier, ISpecialisedSoldier
    {
        private Corps corps;
        private string[] vallidCorps = new string[] { "Airfoce", "Marines" };
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public Corps Corps { get; private set; }

        public override string ToString()
       => base.ToString() + $"{Environment.NewLine}Corps: {Corps}";
    }
}
