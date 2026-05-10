using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Truck : Vehicle, IThermalCar
    {
        public double Tonnage { get; set; }

        public void Refuel(double amount)
        {
            this.FuelLevel += amount;
        }

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} ({Color ?? "Unknown"}) - Tonnage: {Tonnage}T, Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L";
        }
    }
}