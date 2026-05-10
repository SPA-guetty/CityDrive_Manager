using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Car : Vehicle
    {
        public string? Model { get; set; }

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} {Model ?? "Unknown"} ({Color ?? "Unknown"}) - Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L";
        }
    }
}