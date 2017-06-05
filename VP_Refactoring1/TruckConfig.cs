using System;
using System.Globalization;

namespace VP_Refactoring1
{
    public class TruckConfig
    {
        private Exec _exec;

        public TruckConfig(Exec exec)
        {
            _exec = exec;
        }

        public string ByTruck(ICommandManager commandManager, string vehicleType)
        {
            string result;
            if (vehicleType != "truck")
            {
                result = "";
            }
            else
            {
                result = _exec.VehiclePark.InsertTruck(new Truck(commandManager.ParametersDictionary["licensePlate"], commandManager.ParametersDictionary["owner"],
                    int.Parse(commandManager.ParametersDictionary["hours"])),
                    int.Parse(commandManager.ParametersDictionary["sector"]),
                    int.Parse(commandManager.ParametersDictionary["place"]),
                    DateTime.Parse(commandManager.ParametersDictionary["time"], null, DateTimeStyles.RoundtripKind));
            }

            return result;
        }
    }
}