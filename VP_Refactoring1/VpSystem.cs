using Himineu_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiclePark3;

namespace vp_system_himineu
{
	internal class v : IVehiclePark
	{
		public layout layout;

		public DATA DATA;

		public v(int numberOfSectors, int placesPerSector)
		{
			this.layout = new layout(numberOfSectors, placesPerSector);
			this.DATA = new DATA(numberOfSectors);
		}

		public string InsertCar(Carro carro, int s, int p, DateTime t)
		{
			bool flag = s > this.layout.sectors;
			string result;
			if (flag)
			{
				result = string.Format("There is no sector {0} in the park", s);
			}
			else
			{
				bool flag2 = p > this.layout.places_sec;
				if (flag2)
				{
					result = string.Format("There is no place {0} in sector {1}", p, s);
				}
				else
				{
					bool flag3 = this.DATA.park.ContainsKey(string.Format("({0},{1})", s, p));
					if (flag3)
					{
						result = string.Format("The place ({0},{1}) is occupied", s, p);
					}
					else
					{
						bool flag4 = this.DATA.números.ContainsKey(carro.LicensePlate);
						if (flag4)
						{
							result = string.Format("There is already a vehicle with license plate {0} in the park", carro.LicensePlate);
						}
						else
						{
							this.DATA.carros_inpark[carro] = string.Format("({0},{1})", s, p);
							this.DATA.park[string.Format("({0},{1})", s, p)] = carro;
							this.DATA.números[carro.LicensePlate] = carro;
							this.DATA.d[carro] = t;
							this.DATA.ow[carro.Owner].Add(carro);
							this.DATA.count[s - 1]--;
							result = string.Format("{0} parked successfully at place ({1},{2})", carro.GetType().Name, s, p);
						}
					}
				}
			}
			return result;
		}

		public string InsertMotorbike(Moto moto, int s, int p, DateTime t)
		{
			bool flag = s > this.layout.sectors;
			string result;
			if (flag)
			{
				result = string.Format("There is no sector {0} in the park", s);
			}
			else
			{
				bool flag2 = p > this.layout.places_sec;
				if (flag2)
				{
					result = string.Format("There is no place {0} in sector {1}", p, s);
				}
				else
				{
					bool flag3 = this.DATA.park.ContainsKey(string.Format("({0},{1})", s, p));
					if (flag3)
					{
						result = string.Format("The place ({0},{1}) is occupied", s, p);
					}
					else
					{
						bool flag4 = this.DATA.números.ContainsKey(moto.LicensePlate);
						if (flag4)
						{
							result = string.Format("There is already a vehicle with license plate {0} in the park", moto.LicensePlate);
						}
						else
						{
							this.DATA.carros_inpark[moto] = string.Format("({0},{1})", s, p);
							this.DATA.park[string.Format("({0},{1})", s, p)] = moto;
							this.DATA.números[moto.LicensePlate] = moto;
							this.DATA.d[moto] = t;
							this.DATA.ow[moto.Owner].Add(moto);
							this.DATA.count[s - 1]++;
							result = string.Format("{0} parked successfully at place ({1},{2})", moto.GetType().Name, s, p);
						}
					}
				}
			}
			return result;
		}

		public string InsertTruck(Caminhão caminhão, int s, int p, DateTime t)
		{
			bool flag = s > this.layout.sectors;
			string result;
			if (flag)
			{
				result = string.Format("There is no sector {0} in the park", s);
			}
			else
			{
				bool flag2 = p > this.layout.places_sec;
				if (flag2)
				{
					result = string.Format("There is no place {0} in sector {1}", p, s);
				}
				else
				{
					bool flag3 = this.DATA.park.ContainsKey(string.Format("({0},{1})", s, p));
					if (flag3)
					{
						result = string.Format("The place ({0},{1}) is occupied", s, p);
					}
					else
					{
						bool flag4 = this.DATA.números.ContainsKey(caminhão.LicensePlate);
						if (flag4)
						{
							result = string.Format("There is already a vehicle with license plate {0} in the park", caminhão.LicensePlate);
						}
						else
						{
							this.DATA.carros_inpark[caminhão] = string.Format("({0},{1})", s, p);
							this.DATA.park[string.Format("({0},{1})", s, p)] = caminhão;
							this.DATA.números[caminhão.LicensePlate] = caminhão;
							this.DATA.d[caminhão] = t;
							this.DATA.ow[caminhão.Owner].Add(caminhão);
							result = string.Format("{0} parked successfully at place ({1},{2})", caminhão.GetType().Name, s, p);
						}
					}
				}
			}
			return result;
		}

		public string ExitVehicle(string l_pl, DateTime end, decimal money)
		{
			IVehicle vehicle = this.DATA.números.ContainsKey(l_pl) ? this.DATA.números[l_pl] : null;
			bool flag = vehicle == null;
			string result;
			if (flag)
			{
				result = string.Format("There is no vehicle with license plate {0} in the park", l_pl);
			}
			else
			{
				DateTime start = this.DATA.d[vehicle];
				int endd = (int)Math.Round((end - start).TotalHours);
				StringBuilder ticket = new StringBuilder();
				ticket.AppendLine(new string('*', 20)).AppendFormat("{0}", vehicle.ToString()).AppendLine().AppendFormat("at place {0}", this.DATA.carros_inpark[vehicle]).AppendLine().AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate).AppendLine().AppendFormat("Overtime rate: ${0:F2}", (endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero).AppendLine().AppendLine(new string('-', 20)).AppendFormat("Total: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate + ((endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero)).AppendLine().AppendFormat("Paid: ${0:F2}", money).AppendLine().AppendFormat("Change: ${0:F2}", money - (vehicle.ReservedHours * vehicle.RegularRate + ((endd > vehicle.ReservedHours) ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : decimal.Zero))).AppendLine().Append(new string('*', 20));
				int sector = int.Parse(this.DATA.carros_inpark[vehicle].Split(new string[]
				{
					"(",
					",",
					")"
				}, StringSplitOptions.RemoveEmptyEntries)[0]);
				this.DATA.park.Remove(this.DATA.carros_inpark[vehicle]);
				this.DATA.carros_inpark.Remove(vehicle);
				this.DATA.números.Remove(vehicle.LicensePlate);
				this.DATA.d.Remove(vehicle);
				this.DATA.ow.Remove(vehicle.Owner, vehicle);
				this.DATA.count[sector - 1]--;
				result = ticket.ToString();
			}
			return result;
		}

		public string GetStatus()
		{
			IEnumerable<string> places = this.DATA.count.Select((int sssss, int iiiii) => string.Format("Sector {0}: {1} / {2} ({2}% full)", new object[]
			{
				iiiii + 1,
				sssss,
				this.layout.places_sec,
				Math.Round((double)sssss / (double)this.layout.places_sec * 100.0)
			}));
			return string.Join(Environment.NewLine, places);
		}

		public string FindVehicle(string l_pl)
		{
			IVehicle vehicle = this.DATA.números.ContainsKey(l_pl) ? this.DATA.números[l_pl] : null;
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
			bool flag = !(from v in this.DATA.park.Values
			where v.Owner == owner
			select v).Any<IVehicle>();
			string result;
			if (flag)
			{
				result = string.Format("No vehicles by {0}", owner);
			}
			else
			{
				List<IVehicle> found = this.DATA.park.Values.ToList<IVehicle>();
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
			select string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.DATA.carros_inpark[vehicle]));
		}
	}
}
