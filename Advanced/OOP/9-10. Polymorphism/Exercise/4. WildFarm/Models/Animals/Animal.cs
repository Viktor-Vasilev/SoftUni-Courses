

using E4WildFarm.Exceptions;
using E4WildFarm.Models.Animals.Contracts;
using E4WildFarm.Models.Food.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E4WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {

        private const string UneatableFoodMessage = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;

        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();
        
        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PrefferedFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new UneatableFoodException(string.Format(UneatableFoodMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;

            this.FoodEaten += food.Quantity;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }


    }
}
