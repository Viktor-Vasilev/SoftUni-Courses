﻿namespace Animals
{
    using System;

    public class Kitten : Cat
    {
      
        private const string KittenGender = "Female";

        
        public Kitten(string name, int age) : base(name, age, KittenGender)
        {

        }

        
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}