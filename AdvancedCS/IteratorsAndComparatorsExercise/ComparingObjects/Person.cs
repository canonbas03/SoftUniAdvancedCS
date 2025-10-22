using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    internal class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person? other)
        {
            if(other == null) return 1;

            int nameComparison = Comparer<string>.Default.Compare(Name, other.Name);
            if(nameComparison != 0) return nameComparison;

            int ageComparison = Comparer<int>.Default.Compare(Age, other.Age);
            if(ageComparison != 0) return ageComparison;

            int townComparison = Comparer<string>.Default.Compare(Town,other.Town);
            return townComparison;
        }
    }
}
