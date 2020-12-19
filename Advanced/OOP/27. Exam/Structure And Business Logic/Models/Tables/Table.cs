using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private decimal pricePerPerson;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => (IReadOnlyCollection<IBakedFood>)this.foodOrders;
        public IReadOnlyCollection<IBakedFood> Drinks => (IReadOnlyCollection<IBakedFood>)this.drinkOrders;

        public int TableNumber { get;}
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get 
            { 
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }
        public virtual decimal PricePerPerson { get;}

        public decimal Price => PricePerPerson * NumberOfPeople;

        bool ITable.IsReserved => throw new NotImplementedException();

        public void Clear()
        {

            foodOrders.Clear();
            drinkOrders.Clear();
            Capacity += NumberOfPeople;
            IsReserved = false;

        }

        public bool IsReserved { get; private set; }

        public decimal GetBill()
        {
            decimal totalSum = foodOrders.Sum(f => f.Price) + drinkOrders.Sum(d => d.Price) + Price;

            return totalSum;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            if (IsReserved == true)
            {
                drinkOrders.Add(drink);
            }
        }

        public void OrderFood(IBakedFood food)
        {
            if (IsReserved == true)
            {
                foodOrders.Add(food);
            }
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
            Capacity -= NumberOfPeople;

        }

    }
}
