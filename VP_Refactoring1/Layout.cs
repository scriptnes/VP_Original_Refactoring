using System;

namespace VP_Refactoring1
{
    public class Layout 
    {
        public int Sectors;

        public int PlacesSec;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            bool flag = numberOfSectors <= 0;
            if (flag)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }
            this.Sectors = numberOfSectors;
            bool flag2 = placesPerSector <= 0;
            if (flag2)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }
            this.PlacesSec = placesPerSector;
        }
    }
}
