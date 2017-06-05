using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;
using VehiclePark3;
using vp_system_himineu;

namespace Comandos
{
	internal class exec
	{
		public class comando : IComando
		{
			public string nome
			{
				get;
				set;
			}

			public IDictionary<string, string> parâmetros
			{
				get;
				set;
			}

			public comando(string str)
			{
				this.nome = str.Substring(0, str.IndexOf(' '));
				this.parâmetros = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
			}
		}

		private v VehiclePark
		{
			get;
			set;
		}

		public string execução(IComando c)
		{
			bool flag = c.nome != "SetupPark" && this.VehiclePark == null;
			string result;
			if (flag)
			{
				result = "The vehicle park has not been set up";
			}
			else
			{
				string nome = c.nome;
				if (!(nome == "SetupPark"))
				{
					if (!(nome == "Рark"))
					{
						if (!(nome == "Exit"))
						{
							if (!(nome == "Status"))
							{
								if (!(nome == "FindVehicle"))
								{
									if (!(nome == "VehiclesByOwner"))
									{
										throw new IndexOutOfRangeException("Invalid command.");
									}
									result = this.VehiclePark.FindVehiclesByOwner(c.parâmetros["owner"]);
								}
								else
								{
									result = this.VehiclePark.FindVehicle(c.parâmetros["licensePlate"]);
								}
							}
							else
							{
								result = this.VehiclePark.GetStatus();
							}
						}
						else
						{
							result = this.VehiclePark.ExitVehicle(c.parâmetros["licensePlate"], DateTime.Parse(c.parâmetros["time"], null, DateTimeStyles.RoundtripKind), decimal.Parse(c.parâmetros["money"]));
						}
					}
					else
					{
						string a = c.parâmetros["type"];
						if (!(a == "car"))
						{
							if (!(a == "motorbike"))
							{
								if (!(a == "truck"))
								{
									result = "";
								}
								else
								{
									result = this.VehiclePark.InsertTruck(new Caminhão(c.parâmetros["licensePlate"], c.parâmetros["owner"], int.Parse(c.parâmetros["hours"])), int.Parse(c.parâmetros["sector"]), int.Parse(c.parâmetros["place"]), DateTime.Parse(c.parâmetros["time"], null, DateTimeStyles.RoundtripKind));
								}
							}
							else
							{
								result = this.VehiclePark.InsertMotorbike(new Moto(c.parâmetros["licensePlate"], c.parâmetros["owner"], int.Parse(c.parâmetros["hours"])), int.Parse(c.parâmetros["sector"]), int.Parse(c.parâmetros["place"]), DateTime.Parse(c.parâmetros["time"], null, DateTimeStyles.RoundtripKind));
							}
						}
						else
						{
							result = this.VehiclePark.InsertCar(new Carro(c.parâmetros["licensePlate"], c.parâmetros["owner"], int.Parse(c.parâmetros["hours"])), int.Parse(c.parâmetros["sector"]), int.Parse(c.parâmetros["place"]), DateTime.Parse(c.parâmetros["time"], null, DateTimeStyles.RoundtripKind));
						}
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
