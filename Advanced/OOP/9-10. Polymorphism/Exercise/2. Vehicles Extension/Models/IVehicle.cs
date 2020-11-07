
namespace Vehicles.Models
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        bool Drive(double distance);

        void Refuel(double liters);

        bool HasAirConditioner { get; }

        double AirConditionerFuelConsumpion { get; }

        double TankCapacity { get; }

        void StartAirConditioner();

        void StopAirConditioner();
    }
}
