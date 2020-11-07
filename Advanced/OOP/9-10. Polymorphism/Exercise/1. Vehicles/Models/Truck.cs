

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
       
        
        private const double DefaultAirConditionerFuelConsumpion = 1.6;

        private const double RefuelPercentage = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumpion => DefaultAirConditionerFuelConsumpion;

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * RefuelPercentage;
            // base.Refuel(liters * RefuelPercentage); --> може и така - викаме базовото и го променяме
        }
    }
}
