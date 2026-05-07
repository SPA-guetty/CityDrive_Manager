using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Vehicle
    {
        public String Brand { get; set; }
        public String Color { get; set; }
        public double CurrentSpeed { get; set; }
        public double FuelLevel { get; set; }

        public static void Accelerate()
        {
            if (this.FuelLevel >= 1)
            {
                this.CurrentSpeed += 10;
                this.FuelLevel -= 1;
            }
        }

        public static void Brake()
        {
            this.CurrentSpeed -= 10;
            if (this.CurrentSpeed < 10)
            {
                this.CurrentSpeed = 10;
            }
        }
    }
}