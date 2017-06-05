using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VP_Refactoring1
{
    public class VehicleSystem : IVehiclePark 
	{
		public Layout Layout;

		public DataStructure DataStructure;
        private readonly InsertAllType _insertAllType;

        public VehicleSystem(int numberOfSectors, int placesPerSector)
		{
			this.Layout = new Layout(numberOfSectors, placesPerSector);
			this.DataStructure = new DataStructure(numberOfSectors);
            _insertAllType = new InsertAllType(this);
		}

		public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
		{
		    return _insertAllType.InsertCar(car, sector, placeNumber, startTime);
		}

        public string InsertMotorbike(Moto moto, int sector, int placeNumber, DateTime startTime)
        {
            return _insertAllType.InsertMotorbike(moto, sector, placeNumber, startTime);
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            return _insertAllType.InsertTruck(truck, sector, placeNumber, startTime);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal paid)  
		{
			IVehicle vehicle = this.DataStructure.LicensePlateDictionary.ContainsKey(licensePlate) ? this.DataStructure.LicensePlateDictionary[licensePlate] : null;
			bool flag = vehicle == null;
			string result;
			if (flag)
			{
				result = string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
			}
			else
			{
				DateTime beginDateTime = this.DataStructure.DateDictionary[vehicle];
				int endDateTime = (int)Math.Round((endTime - beginDateTime).TotalHours);
				StringBuilder ticket = new StringBuilder();
				ticket.
                    AppendLine(new string('*', 20)).AppendFormat("{0}", vehicle).
                    AppendLine().AppendFormat("at place {0}", this.DataStructure.CarDictionaryInPark[vehicle]).
                    AppendLine().AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate).
                    AppendLine().AppendFormat("Overtime rate: ${0:F2}", (endDateTime > vehicle.ReservedHours) ? ((endDateTime - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero).
                    AppendLine().AppendLine(new string('-', 20)).AppendFormat("Total: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate + ((endDateTime > vehicle.ReservedHours) ? ((endDateTime - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero)).
                    AppendLine().AppendFormat("Paid: ${0:F2}", paid).
                    AppendLine().AppendFormat("Change: ${0:F2}", paid - (vehicle.ReservedHours * vehicle.RegularRate + ((endDateTime > vehicle.ReservedHours) ? ((endDateTime - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero))).
                    AppendLine().Append(new string('*', 20));
				int sector = int.Parse(this.DataStructure.CarDictionaryInPark[vehicle].Split(new string[]
				{
					"(",
					",",
					")"
				}, StringSplitOptions.RemoveEmptyEntries)[0]);
				this.DataStructure.ParkDictionary.Remove(this.DataStructure.CarDictionaryInPark[vehicle]);
				this.DataStructure.CarDictionaryInPark.Remove(vehicle);
				this.DataStructure.LicensePlateDictionary.Remove(vehicle.LicensePlate);
				this.DataStructure.DateDictionary.Remove(vehicle);
				this.DataStructure.OwnerMultiDictionary.Remove(vehicle.Owner, vehicle);
				this.DataStructure.CountNumberOfSectors[sector - 1]--;
				result = ticket.ToString();
			}
			return result;
		}

		public string GetStatus()
		{
			IEnumerable<string> places = this.DataStructure.CountNumberOfSectors.Select((int sssss, int iiiii) => string.Format("Sector {0}: {1} / {2} ({2}% full)", new object[]
			{
				iiiii + 1,
				sssss,
				this.Layout.PlacesSec,
				Math.Round((double)sssss / (double)this.Layout.PlacesSec * 100.0)
			}));
			return string.Join(Environment.NewLine, places);
		}

		public string FindVehicle(string licensePlate)
		{
			IVehicle vehicle = this.DataStructure.LicensePlateDictionary.ContainsKey(licensePlate) ? this.DataStructure.LicensePlateDictionary[licensePlate] : null;
			bool flag = vehicle == null;
			string result;
			if (flag)
			{
				result = string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
			}
			else
			{
				result = this.Input(new IVehicle[]
				{
					vehicle
				});
			}
			return result;
		}

		public string FindVehiclesByOwner(string owner)
		{
			bool flag = !(from v in this.DataStructure.ParkDictionary.Values
			where v.Owner == owner
			select v).Any<IVehicle>();
			string result;
			if (flag)
			{
				result = string.Format("No vehicles by {0}", owner);
			}
			else
			{
				List<IVehicle> found = this.DataStructure.ParkDictionary.Values.ToList<IVehicle>();
				List<IVehicle> res = found;
                //Func < IVehicle, bool> <>9__1;
				foreach (IVehicle f in found)
				{
					IEnumerable<IVehicle> arg_A3_0 = res;
					Func<IVehicle, bool> arg_A3_1;
					//if ((arg_A3_1 = <>9__1) == null)
					//{
					//	arg_A3_1 = (<>9__1 = v => v.Owner == owner);
					//}
					//res = arg_A3_0.Where(arg_A3_1).ToList<IVehicle>();
				}
				result = string.Join(Environment.NewLine, new string[]
				{
					this.Input(res)
				});
			}
			return result;
		}

		private string Input(IEnumerable<IVehicle> carros)
		{
			return string.Join(Environment.NewLine, from vehicle in carros
			select string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.DataStructure.CarDictionaryInPark[vehicle]));
		}
	}
}
