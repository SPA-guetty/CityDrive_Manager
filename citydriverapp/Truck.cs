using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Truck : Vehicles.Vehicle
    {
        public double Tonnage { get; set; }

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} ({Color ?? "Unknown"}) - Tonnage: {Tonnage}T, Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L";
        }
    }
}