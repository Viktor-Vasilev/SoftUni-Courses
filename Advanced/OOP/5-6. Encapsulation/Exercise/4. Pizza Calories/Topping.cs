using System;
using System.Collections.Generic;

namespace E4PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 50;

        private readonly Dictionary<string, double> DefaultTypes = new Dictionary<string, double>
        {
            {"meat", 1.2 },
            {"veggies", 0.8},
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            set
            {
                if (!this.DefaultTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value.ToLower();
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                this.weight = value; 
            
            }
        }


        public double CaloriesPerGram => BaseCaloriesPerGram * this.DefaultTypes[this.Type];

        public double TotalCalories => this.CaloriesPerGram * this.Weight;

    }
}
