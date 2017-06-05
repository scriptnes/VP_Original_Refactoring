using System;
using System.Globalization;

namespace VP_Refactoring1
{
    public class MotoConfig
    {
        private Exec _exec;

        public MotoConfig(Exec exec)
        {
            _exec = exec;
        }

        public string ByMoto(ICommandManager commandManager, string vehicleType)
        {
            string result;
            if (vehicleType != "motorbike")
            {
                result = _exec.TruckConfig.ByTruck(commandManager, vehicleType);
            }
            else
            {
                result = ByMotoElse(commandManager);
            }

            return result;
        }

        private string ByMotoElse(ICommandManager commandManager)
        {
            return _exec.VehiclePark.InsertMotorbike(
                new Moto(commandManager.ParametersDictionary["licensePlate"],
                commandManager.ParametersDictionary["owner"],
                int.Parse(commandManager.ParametersDictionary["hours"])),
                int.Parse(commandManager.ParametersDictionary["sector"]),
                int.Parse(commandManager.ParametersDictionary["place"]),
                DateTime.Parse(commandManager.ParametersDictionary["time"], null, DateTimeStyles.RoundtripKind));
        }

    }

}
