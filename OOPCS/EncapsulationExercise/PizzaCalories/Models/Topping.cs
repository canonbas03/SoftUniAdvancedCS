namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string type;
        private double weight;

        private readonly Dictionary<string, double> modifierByType;

        public Topping(string type, double weight)
        {
            modifierByType = new()
            {
                {"meat", 1.2},
                {"veggies", 0.8},
                {"cheese", 1.1},
                {"sauce", 0.9},
            };
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!modifierByType.ContainsKey(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                type = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");

                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeModifier = modifierByType[type.ToLower()];
                return typeModifier * Weight * BaseCaloriesPerGram;
            }
          
        }
    }
}
