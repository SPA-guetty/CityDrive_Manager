using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Hybridcar : Vehicle
    {
        public double BatteryLevel { get; set; }

        public override void Accelerate()
        {
            if (this.BatteryLevel >= 2)
            {
                this.BatteryLevel -= 2;
                this.CurrentSpeed += 10;
            }
            else 
            {
                if (this.FuelLevel >= 1)
                {
                    this.CurrentSpeed += 10;
                    this.FuelLevel -= 1;
                }
            }
        }
    }
}