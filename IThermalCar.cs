using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public interface IThermalCar
    {
        double FuelLevel { get; set; }
        void Refuel(double amount);
    }
}
