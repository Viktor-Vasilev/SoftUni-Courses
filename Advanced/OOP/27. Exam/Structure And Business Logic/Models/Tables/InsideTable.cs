using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.50m;
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => (IReadOnlyCollection<IBakedFood>)this.foodOrders;
        public IReadOnlyCollection<IBakedFood> Drinks => (IReadOnlyCollection<IBakedFood>)this.drinkOrders;

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override decimal GetBill()
        {
            throw new NotImplementedException();
        }

        public override string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }

        public override void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        public override void OrderFood(IBakedFood food)
        {
            throw new NotImplementedException();
        }

        public override void Reserve(int numberOfPeople)
        {
           
        }
    }
}
