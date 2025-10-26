using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomkatSound = "MEOW";

        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override string ProduceSound()=> TomkatSound;
    }
}
