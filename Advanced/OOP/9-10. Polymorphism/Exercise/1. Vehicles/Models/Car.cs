﻿

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumpion = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumpion => DefaultAirConditionerFuelConsumpion;
    }
}
