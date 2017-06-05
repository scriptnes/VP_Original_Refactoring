using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiclePark3;

namespace VP_Refactoring1
{
    public class VehicleSystem : IVehiclePark 
	{
		public Layout layout;

		public DataStructure DATA;
        private readonly InsertAllType _insertAllType;

        public VehicleSystem(int numberOfSectors, int placesPerSector)
		{
			this.layout = new Layout(numberOfSectors, placesPerSector);
			this.DATA = new DataStructure(numberOfSectors);
            _insertAllType = new InsertAllType(this);
		}

		public string InsertCar(Car carro, int s, int p, DateTime t)
		{
		    return _insertAllType.InsertCar(carro, s, p, t);
		}

        public string InsertMotorbike(Moto moto, int s, int p, DateTime t)
        {
            return _insertAllType.InsertMotorbike(moto, s, p, t);
        }

        public string InsertTruck(Truck caminhão, int s, int p, DateTime t)
        {
            return _insertAllType.InsertTruck(caminhão, s, p, t);
        }

        public string ExitVehicle(string l_pl, DateTime end, decimal money)
		{
			IVehicle vehicle = this.DATA.LicensePlateDictionary.ContainsKey(l_pl) ? this.DATA.LicensePlateDictionary[l_pl] : null;
			bool flag = vehicle == null;
			string result;
			if (flag)
			{
				result = string.Format("There is no vehicle with license plate {0} in the park", l_pl);
			}
			else
			{
				DateTime start = this.DATA.DateDictionary[vehicle];
				int endd = (int)Math.Round((end - start).TotalHours);
				StringBuilder ticket = new StringBuilder();
				ticket.AppendLine(new string('*', 20)).AppendFormat("{0}", vehicle.ToString()).AppendLine().AppendFormat("at place {0}", this.DATA.CarDictionaryInPark[vehicle]).AppendLine().AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate).AppendLine().AppendFormat("Overtime rate: ${0:F2}", (endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero).AppendLine().AppendLine(new string('-', 20)).AppendFormat("Total: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate + ((endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero)).AppendLine().AppendFormat("Paid: ${0:F2}", money).AppendLine().AppendFormat("Change: ${0:F2}", money - (vehicle.ReservedHours * vehicle.RegularRate + ((endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero))).AppendLine().Append(new string('*', 20));
				int sector = int.Parse(this.DATA.CarDictionaryInPark[vehicle].Split(new string[]
				{
					"(",
					",",
					")"
				}, StringSplitOptions.RemoveEmptyEntries)[0]);
				this.DATA.ParkDictionary.Remove(this.DATA.CarDictionaryInPark[vehicle]);
				this.DATA.CarDictionaryInPark.Remove(vehicle);
				this.DATA.LicensePlateDictionary.Remove(vehicle.LicensePlate);
				this.DATA.DateDictionary.Remove(vehicle);
				this.DATA.OwnerMultiDictionary.Remove(vehicle.Owner, vehicle);
				this.DATA.CountNumberOfSectors[sector - 1]--;
				result = ticket.ToString();
			}
			return result;
		}

		public string GetStatus()
		{
			IEnumerable<string> places = this.DATA.CountNumberOfSectors.Select((int sssss, int iiiii) => string.Format("Sector {0}: {1} / {2} ({2}% full)", new object[]
			{
				iiiii + 1,
				sssss,
				this.layout.PlacesSec,
				Math.Round((double)sssss / (double)this.layout.PlacesSec * 100.0)
			}));
			return string.Join(Environment.NewLine, places);
		}

		public string FindVehicle(string l_pl)
		{
			IVehicle vehicle = this.DATA.LicensePlateDictionary.ContainsKey(l_pl) ? this.DATA.LicensePlateDictionary[l_pl] : null;
			bool flag = vehicle == null;
			string result;
			if (flag)
			{
				result = string.Format("There is no vehicle with license plate {0} in the park", l_pl);
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
			bool flag = !(from v in this.DATA.ParkDictionary.Values
			where v.Owner == owner
			select v).Any<IVehicle>();
			string result;
			if (flag)
			{
				result = string.Format("No vehicles by {0}", owner);
			}
			else
			{
				List<IVehicle> found = this.DATA.ParkDictionary.Values.ToList<IVehicle>();
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
			select string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.DATA.CarDictionaryInPark[vehicle]));
		}
	}
}
