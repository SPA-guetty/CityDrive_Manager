using System;

namespace CITYDRIVE_MANAGER.Vehicles
{
    public interface IElectricCar
    {
        double BatteryLevel { get; set; }
        void Recharge(double amount);
    }
}
