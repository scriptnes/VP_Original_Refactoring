using System;
using System.Text;
using System.Text.RegularExpressions;

namespace VP_Refactoring1
{
	public class Moto : IVehicle
	{
		private string _licensePlateMoto;   

		private string _personMoto;

		private decimal _regularMoto;

		private decimal _rate;

		private int _hours;

		public string LicensePlate
		{
			get
			{
				return this._licensePlateMoto;
			}
			set
			{
				bool flag = !Regex.IsMatch(value, "^[A-Z]{1}\\d{3}[A-Z]{2,}$");
				if (flag)
				{
					throw new ArgumentException("The license plate number is invalid.");
				}
				this._licensePlateMoto = value;
			}
		}

		public string Owner
		{
			get
			{
				return this._personMoto;
			}
			set
			{
				bool flag = string.IsNullOrEmpty(value);
				if (flag)
				{
					throw new InvalidCastException("The owner is required.");
				}
				this._personMoto = value;
			}
		}

		public decimal RegularRate
		{
			get
			{
				return this._regularMoto;
			}
			set
			{
				bool flag = value < decimal.Zero;
				if (flag)
				{
					throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative.", new object[0]));
				}
				this._regularMoto = value;
			}
		}

		public decimal OvertimeRate
		{
			get
			{
				return this._rate;
			}
			set
			{
				bool flag = value < decimal.Zero;
				if (flag)
				{
					throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative.", new object[0]));
				}
				this._rate = value;
			}
		}

		public int ReservedHours
		{
			get
			{
				return this._hours;
			}
			set
			{
				bool flag = value <= 0;
				if (flag)
				{
					throw new ArgumentException("The reserved hours must be positive.");
				}
				this._hours = value;
			}
		}

		public override string ToString()
		{
			StringBuilder vehicle = new StringBuilder();
			vehicle.AppendFormat("{0} [{2}], owned by {1}", base.GetType().Name, this.LicensePlate, this.Owner);
			return vehicle.ToString();
		}

        public Moto(string licensePlate, string person, int hours)
        {
            this.RegularRate = 1.35m;
            this.OvertimeRate = 3m;
        }
    }
}
