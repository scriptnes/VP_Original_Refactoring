using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Himineu_system
{
	internal class DATA
	{
		public Dictionary<IVehicle, string> carros_inpark
		{
			get;
			set;
		}

		public Dictionary<string, IVehicle> park
		{
			get;
			set;
		}

		public Dictionary<string, IVehicle> números
		{
			get;
			set;
		}

		public Dictionary<IVehicle, DateTime> d
		{
			get;
			set;
		}

		public MultiDictionary<string, IVehicle> ow
		{
			get;
			set;
		}

		public int[] count
		{
			get;
			set;
		}

		public DATA(int numberOfSectors)
		{
			this.carros_inpark = new Dictionary<IVehicle, string>();
			this.park = new Dictionary<string, IVehicle>();
			this.números = new Dictionary<string, IVehicle>();
			this.d = new Dictionary<IVehicle, DateTime>();
			this.ow = new MultiDictionary<string, IVehicle>(false);
			this.count = new int[numberOfSectors];
		}
	}
}
