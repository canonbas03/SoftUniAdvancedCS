using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
            : base(model, color)
        {
            this.Battery = batteries;
        }
        public int Battery { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" with {Battery} Batteries";
        }
    }
}
