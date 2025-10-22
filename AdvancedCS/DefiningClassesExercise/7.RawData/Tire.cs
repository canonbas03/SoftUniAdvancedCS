using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    internal class Tire
    {
        public int Age { get; set; }    
        public double Pressure { get; set; }

        public Tire(double pressure, int age)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}
