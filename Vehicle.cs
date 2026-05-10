using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public abstract class Vehicle
    {
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public double CurrentSpeed { get; set; }
        public double FuelLevel { get; set; }

        public virtual void Accelerate()
        {
            if (this.FuelLevel >= 1)
            {
                this.CurrentSpeed += 10;
                this.FuelLevel -= 1;
            }
        }

        public virtual void Brake()
        {
            this.CurrentSpeed -= 10;
            if (this.CurrentSpeed < 0)
            {
                this.CurrentSpeed = 0;
            }
        }

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} ({Color ?? "Unknown"}) - Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L";
        }
    }
}