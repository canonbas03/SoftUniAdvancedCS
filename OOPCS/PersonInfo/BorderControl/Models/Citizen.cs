using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
