﻿namespace Restaurant
{
    public class Food : Product
    {
        
        protected Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }

       
        public double Grams { get; private set; }
    }
}