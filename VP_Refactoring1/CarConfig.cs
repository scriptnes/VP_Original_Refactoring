using System;
using System.Globalization;

namespace VP_Refactoring1
{
    public class CarConfig
    {
        private Exec _exec;

        public CarConfig(Exec exec)
        {
            _exec = exec;
        }

        public string ByCar(ICommandManager commandManager, string vehicleType)
        {
            string result;
            result = ByCarElse(commandManager, vehicleType);

            return result;
        }

        private string ByCarElse(ICommandManager commandManager, string vehicleType)
        {
            string result;
            if (vehicleType != "car")
            {
                result = _exec.MotoConfig.ByMoto(commandManager, vehicleType);
            }
            else
            {
                result = ByCarElseFunc1(commandManager);
            }

            return result;
        }

        private string ByCarElseFunc1(ICommandManager commandManager)
        {
            return CarEntry1(commandManager);
        }

        private string CarEntry1(ICommandManager commandManager)
        {
            return _exec.VehiclePark.InsertCar(
                new Car(commandManager.ParametersDictionary["licensePlate"],
                commandManager.ParametersDictionary["owner"],
                int.Parse(commandManager.ParametersDictionary["hours"])),
                int.Parse(commandManager.ParametersDictionary["sector"]),
                int.Parse(commandManager.ParametersDictionary["place"]),
                DateTime.Parse(commandManager.ParametersDictionary["time"], null, DateTimeStyles.RoundtripKind));
        }
    }
}