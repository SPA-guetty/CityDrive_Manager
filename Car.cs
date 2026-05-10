using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Car : Vehicle, IThermalCar
    {
        public string? Model { get; set; }

        public void Refuel(double amount)
        {
            this.FuelLevel += amount;
        }

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} {Model ?? "Unknown"} ({Color ?? "Unknown"}) - Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L";
        }
    }
}