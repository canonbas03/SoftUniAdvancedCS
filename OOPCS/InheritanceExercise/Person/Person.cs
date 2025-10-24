using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public string Name { get; set; }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(value > 0)
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}";
        }
    }
}
