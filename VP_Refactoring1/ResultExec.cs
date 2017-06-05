using System;
using System.Globalization;

namespace VP_Refactoring1
{
    public class ResultExec
    {
        private readonly Exec _exec;

        public ResultExec(Exec exec)
        {
            _exec = exec;
        }

        public string Result(ICommandManager commandManager, bool flag)
        {
            string result;
            if (flag)
            {
                result = "The vehicle park has not been set up";
            }
            else
            {
                string commandLabel = commandManager.Name;
                if (commandLabel != "SetupPark")
                {
                    if (commandLabel != "Ðark")
                    {
                        if (commandLabel != "Exit")
                        {
                            if (commandLabel != "Status")
                            {
                                if (commandLabel != "FindVehicle")
                                {
                                    if (commandLabel != "VehiclesByOwner")
                                    {
                                        throw new IndexOutOfRangeException("Invalid command.");
                                    }
                                    result = _exec.VehiclePark.FindVehiclesByOwner(commandManager.ParametersDictionary["owner"]);
                                }
                                else
                                {
                                    result = _exec.VehiclePark.FindVehicle(commandManager.ParametersDictionary["licensePlate"]);
                                }
                            }
                            else
                            {
                                result = _exec.VehiclePark.GetStatus();
                            }
                        }
                        else
                        {
                            result = _exec.VehiclePark.ExitVehicle(commandManager.ParametersDictionary["licensePlate"],
                                DateTime.Parse(commandManager.ParametersDictionary["time"], null, DateTimeStyles.RoundtripKind),
                                decimal.Parse(commandManager.ParametersDictionary["money"]));
                        }
                    }
                    else
                    {
                        string vehicleType = commandManager.ParametersDictionary["type"];
                        result = _exec._carConfig.ByCar(commandManager, vehicleType);
                    }
                }
                else
                {
                    result = "Vehicle park created";
                }
            }
            return result;
        }
    }
}