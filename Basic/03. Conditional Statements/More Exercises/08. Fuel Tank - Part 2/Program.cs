using System;

namespace _08._Fuel_Tank___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuel = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();
            double priceGasoline = 2.22;
            double priceDiesel = 2.33;
            double priceGas = 0.93;
            double discountGasoline = 0.18;
            double discountDiesel = 0.12;
            double discountGas = 0.08;
            double total = 0;
            if (fuelType == "Gasoline" && discountCard == "Yes") // ако зарежда бензин и има карта
            {
                if (fuel < 20)
                {
                    total = fuel * (priceGasoline - discountGasoline);
                }
                else if (fuel > 25)
                {
                    total = fuel * (priceGasoline - discountGasoline) * 0.90;
                }
                else
                {
                    total = fuel * (priceGasoline - discountGasoline) * 0.92;
                }
            }
            else if (fuelType == "Gasoline" && discountCard == "No") // ако зарежда бензин и няма карта
            {
                if (fuel < 20)
                {
                    total = fuel * priceGasoline;
                }
                else if (fuel > 25)
                {
                    total = fuel * priceGasoline * 0.90;
                }
                else
                {
                    total = fuel * priceGasoline * 0.92;
                }
            }
            if (fuelType == "Diesel" && discountCard == "Yes")  // ако зарежда дизел и има карта
            {
                if (fuel < 20)
                {
                    total = fuel * (priceDiesel - discountDiesel);
                }
                else if (fuel > 25)
                {
                    total = fuel * (priceDiesel - discountDiesel) * 0.90;
                }
                else
                {
                    total = fuel * (priceDiesel - discountDiesel) * 0.92;
                }
            }
            else if (fuelType == "Diesel" && discountCard == "No")  // ако зарежда бензин и няма карта
            {
                if (fuel < 20)
                {
                    total = fuel * priceDiesel;
                }
                else if (fuel > 25)
                {
                    total = fuel * priceDiesel * 0.90;
                }
                else
                {
                    total = fuel * priceDiesel * 0.92;
                }
            }
            if (fuelType == "Gas" && discountCard == "Yes")  // ако зарежда газ и има карта
            {
                if (fuel < 20)
                {
                    total = fuel * (priceGas - discountGas);
                }
                else if (fuel > 25)
                {
                    total = fuel * (priceGas - discountGas) * 0.90;
                }
                else
                {
                    total = fuel * (priceGas - discountGas) * 0.92;
                }
            }
            else if (fuelType == "Gas" && discountCard == "No")  // ако зарежда газ и няма карта
            {
                if (fuel < 20)
                {
                    total = fuel * priceGas;
                }
                else if (fuel > 25)
                {
                    total = fuel * priceGas * 0.90;
                }
                else
                {
                    total = fuel * priceGas * 0.92;
                }
            }
            Console.WriteLine($"{total:F2} lv.");
        }
    }
}
