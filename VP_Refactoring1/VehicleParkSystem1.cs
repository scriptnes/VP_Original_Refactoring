using System;
using System.Globalization;
using System.Threading;
using VehicleParkSystem2;

namespace VehicleParkSystem1
{
	internal static class vp
	{
		private static void Main()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Mecanismo engine = new Mecanismo();
			engine.Runrunrunrunrun();
		}
	}
}
