using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public class Hybridcar : Vehicle, IThermalCar, IElectricCar
    {
        public double BatteryLevel { get; set; }

        public void Refuel(double amount)
        {
            this.FuelLevel += amount;
        }

        public void Recharge(double amount)
        {
            this.BatteryLevel += amount;
            if (this.BatteryLevel > 100) this.BatteryLevel = 100;
        }

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

        public override string ToString()
        {
            return $"{Brand ?? "Unknown"} ({Color ?? "Unknown"}) - Speed: {CurrentSpeed} km/h, Fuel: {FuelLevel}L, Battery: {BatteryLevel}%";
        }
    }
}