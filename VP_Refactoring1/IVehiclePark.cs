using System;

namespace VP_Refactoring1
{
    public interface IVehiclePark
    {
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        string InsertMotorbike(Moto motorbike, int sector, int placeNumber, DateTime startTime);

        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        string GetStatus();

        string FindVehicle(string licensePlate);

        string FindVehiclesByOwner(string owner);
    }
}
