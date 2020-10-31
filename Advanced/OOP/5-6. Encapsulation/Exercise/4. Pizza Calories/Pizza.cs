using System;
using System.Collections.Generic;

namespace E4PizzaCalories
{
    public class Pizza
    {
        private const int MaxNameLenght = 15;
        private const int MinNameLenght = 1;
        private const int MaxToppingsCount = 10;
        
        private string name;       
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set {

                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLenght || value.Length > MaxNameLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLenght} and {MaxNameLenght} symbols.");
                }
                
                this.name = value; 
            
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public int CountOfToppings => this.toppings.Count;

        public double TotalCalories => CalculateTotalCalories();

       

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppingsCount)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }
            
            this.toppings.Add(topping);      
        }


        private double CalculateTotalCalories()
        {
            double res = this.Dough.TotalCalories;

            foreach (Topping topping in toppings)
            {
                res += topping.TotalCalories;
            }

            return res;
        }






    }
}
