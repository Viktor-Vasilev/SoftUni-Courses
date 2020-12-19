using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

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
            throw new NotImplementedException();
        }
    }
}
