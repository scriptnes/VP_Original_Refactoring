using System;
using VehiclePark3;

internal interface IVehiclePark
{
	string InsertCar(Carro car, int sector, int placeNumber, DateTime startTime);

	string InsertMotorbike(Moto motorbike, int sector, int placeNumber, DateTime startTime);

	string InsertTruck(Caminhão truck, int sector, int placeNumber, DateTime startTime);

	string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

	string GetStatus();

	string FindVehicle(string licensePlate);

	string FindVehiclesByOwner(string owner);
}
