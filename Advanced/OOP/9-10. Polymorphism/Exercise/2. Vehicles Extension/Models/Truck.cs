

using System;
using Vehicles.Utilities;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
       
        
        private const double DefaultAirConditionerFuelConsumpion = 1.6;

        private const double RefuelPercentage = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumpion => DefaultAirConditionerFuelConsumpion;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeFuelAmmount);
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                string msg = string.Format(ExceptionMessages.InvalidFuelAmmount, liters);
                throw new ArgumentException(msg);
            }

            base.Refuel(liters * RefuelPercentage); 
        }
    }
}
