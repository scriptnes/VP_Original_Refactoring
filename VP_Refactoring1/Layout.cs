using System;

internal class layout
{
	public int sectors;

	public int places_sec;

	public layout(int numberOfSectors, int placesPerSector)
	{
		bool flag = numberOfSectors <= 0;
		if (flag)
		{
			throw new DivideByZeroException("The number of sectors must be positive.");
		}
		this.sectors = numberOfSectors;
		bool flag2 = placesPerSector <= 0;
		if (flag2)
		{
			throw new DivideByZeroException("The number of places per sector must be positive.");
		}
		this.places_sec = placesPerSector;
	}
}
