using System.Collections;

namespace EqualityLogic
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person? other)
        {
            if (other == null) return 1;

            int nameComparison = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
            if (nameComparison != 0) return nameComparison;

            return Comparer<int>.Default.Compare(Age, other.Age);
        }

        public bool Equals(Person? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;


            return StringComparer.InvariantCultureIgnoreCase.Equals(this.Name, other.Name)
                && EqualityComparer<int>.Default.Equals(this.Age, other.Age);
        }

        public override bool Equals(object? obj)
            => obj is Person p && this.Equals(p);

        public override int GetHashCode()
        {
            return HashCode.Combine(StringComparer.InvariantCultureIgnoreCase.GetHashCode
                (Name), Age);
        }
    }
}
