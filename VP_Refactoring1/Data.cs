using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace VP_Refactoring1   
{
    public class DataStructure  
	{
		public Dictionary<IVehicle, string> CarDictionaryInPark 
		{
			get;
			set;
		}

		public Dictionary<string, IVehicle> ParkDictionary  
		{
			get;
			set;
		}

		public Dictionary<string, IVehicle> LicensePlateDictionary  
		{
			get;
			set;
		}

		public Dictionary<IVehicle, DateTime> DateDictionary
		{
			get;
			set;
		}

		public MultiDictionary<string, IVehicle> OwnerMultiDictionary   
		{
			get;
			set;
		}

		public int[] CountNumberOfSectors   
		{
			get;
			set;
		}

		public DataStructure(int numberOfSectors)
		{
			this.CarDictionaryInPark = new Dictionary<IVehicle, string>();
			this.ParkDictionary = new Dictionary<string, IVehicle>();
			this.LicensePlateDictionary = new Dictionary<string, IVehicle>();
			this.DateDictionary = new Dictionary<IVehicle, DateTime>();
			this.OwnerMultiDictionary = new MultiDictionary<string, IVehicle>(false);
			this.CountNumberOfSectors = new int[numberOfSectors];
		}
	}
}
