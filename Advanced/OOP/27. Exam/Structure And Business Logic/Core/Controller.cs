using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        IDictionary<string, List<object>> resturantObjects;

        private decimal totalSumResturant;

        public Controller()
        {
            resturantObjects = new Dictionary<string, List<object>> { { "food", new List<object>() }, { "drink", new List<object>() }, { "table", new List<object>() } };

        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            DrinkType drinkType;
            bool parsed = Enum.TryParse<DrinkType>(type, out drinkType);
            if (parsed)
            {
                if (drinkType == DrinkType.Tea)
                {
                    drink = new Tea(name, portion, brand);
                }
                else if (drinkType == DrinkType.Water)
                {
                    drink = new Water(name, portion, brand);
                }
            }


            resturantObjects["drink"].Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            else
            {

            }

            resturantObjects["food"].Add(food);
            return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            else
            {

            }
            resturantObjects["table"].Add(table);

            return $"Added table number { table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITable table in resturantObjects["table"])
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }
            return sb.ToString().TrimEnd();

        }

        public string GetTotalIncome()
        {
            return $"Total income: { totalSumResturant:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = resturantObjects["table"].FirstOrDefault(t => (t as ITable).TableNumber == tableNumber) as ITable;
            int people = table.NumberOfPeople;
            decimal totalSum = table.GetBill();
            totalSumResturant += table.GetBill();
            table.Clear();
            return $"Table: {tableNumber}\nBill: {totalSum:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = resturantObjects["table"].FirstOrDefault(t => (t as ITable).TableNumber == tableNumber) as ITable;
            if (table == null)
            {
                return $"Could not find table { tableNumber}";

            }
            else
            {
                IDrink drink = resturantObjects["drink"].FirstOrDefault(f => (f as IDrink).Name == drinkName) as IDrink;

                if (drink == null || drink.Brand != drinkBrand)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }

            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {

            ITable table = resturantObjects["table"].FirstOrDefault(t => (t as ITable).TableNumber == tableNumber) as ITable;
            if (table == null)
            {
                return $"Could not find table { tableNumber}";

            }
            else
            {
                IBakedFood food = resturantObjects["food"].FirstOrDefault(f => (f as IBakedFood).Name == foodName) as IBakedFood;
                if (food == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }

            }

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = resturantObjects["table"].FirstOrDefault(t => !((t as ITable).IsReserved)) as ITable;
            if (table == null || table.Capacity < numberOfPeople)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }


}