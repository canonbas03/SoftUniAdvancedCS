using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private readonly Dictionary<string, double> modifierByFlourType;
        private readonly Dictionary<string, double> modifierByBakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            modifierByFlourType = new()
            {
                {"white", 1.5 },
                {"wholegrain", 1 }
            };

            modifierByBakingTechnique = new()
            {
                {"crispy",0.9 },
                {"chewy",1.1 },
                {"homemade", 1 }
            };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (!modifierByFlourType.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (!modifierByBakingTechnique.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");

                weight = value;
            }
        }
        public double CalculateCalories()
        {
            double flourTypeModifier = modifierByFlourType[flourType.ToLower()];
            double bakingTechniqueModifier = modifierByBakingTechnique[bakingTechnique.ToLower()];

            return BaseCaloriesPerGram * flourTypeModifier * bakingTechniqueModifier * Weight;
        }
    }
}
