﻿



namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private int food;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food
        {
            get => food;
            private set => food = value;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }

    }
}
