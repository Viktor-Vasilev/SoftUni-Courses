

using System;
using Vehicles.Utilities;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private const double DefaultFuelQuantity = 0;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
            this.HasAirConditioner = hasAirConditioner;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DefaultFuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; }

        public bool HasAirConditioner { get; private set; }

        public abstract double AirConditionerFuelConsumpion { get; }

        public double TankCapacity { get; }

        public bool Drive(double distance)
        {
            double spentFuel = distance * this.FuelConsumption;

            if (HasAirConditioner)
            {
                spentFuel += AirConditionerFuelConsumpion * distance;
            }

            if (this.FuelQuantity < spentFuel)
            {
                return false;
            }

            this.FuelQuantity -= spentFuel;
            return true;
        }

        public virtual void Refuel(double liters)
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
            
            
            
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";

        }

        public void StartAirConditioner()
        {
            this.HasAirConditioner = true;
        }

        public void StopAirConditioner()
        {
            this.HasAirConditioner = false;
        }
    }
}
