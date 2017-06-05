using System;
using System.Text;
using System.Text.RegularExpressions;
using VP_Refactoring1;

namespace VehiclePark3
{
	public class Truck : IVehicle
	{
		private string licenseplate;

		private string person;

		private decimal regularrate;

		private decimal morerate;

		private int hh;

		public string LicensePlate
		{
			get
			{
				return this.licenseplate;
			}
			set
			{
				bool flag = !Regex.IsMatch(value, "^[A-Z]{1}\\d{3}[A-Z]{2,}$");
				if (flag)
				{
					throw new ArgumentException("The license plate number is invalid.");
				}
				this.licenseplate = value;
			}
		}

		public string Owner
		{
			get
			{
				return this.person;
			}
			set
			{
				bool flag = string.IsNullOrEmpty(value);
				if (flag)
				{
					throw new InvalidCastException("The owner is required.");
				}
				this.person = value;
			}
		}

		public decimal RegularRate
		{
			get
			{
				return this.regularrate;
			}
			set
			{
				bool flag = value < decimal.Zero;
				if (flag)
				{
					throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative.", new object[0]));
				}
				this.regularrate = value;
			}
		}

		public decimal OvertimeRate
		{
			get
			{
				return this.morerate;
			}
			set
			{
				bool flag = value < decimal.Zero;
				if (flag)
				{
					throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative.", new object[0]));
				}
				this.morerate = value;
			}
		}

		public int ReservedHours
		{
			get
			{
				return this.hh;
			}
			set
			{
				bool flag = value <= 0;
				if (flag)
				{
					throw new ArgumentException("The reserved hours must be positive.");
				}
				this.hh = value;
			}
		}

		public override string ToString()
		{
			StringBuilder vehicle = new StringBuilder();
			vehicle.AppendFormat("{0} [{2}], owned by {1}", base.GetType().Name, this.LicensePlate, this.Owner);
			return vehicle.ToString();
		}

		public Truck(string licensePlate, string person, int hours) 
		{
			this.RegularRate = 4.75m;
			this.OvertimeRate = 6.2m;
		}
	}
}
