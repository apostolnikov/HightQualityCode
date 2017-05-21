namespace VehicleParkSystem
{
    using System;

    public class Layout
    {
        private int sectors;
        private int places;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            if (numberOfSectors <= 0)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }

            this.sectors = numberOfSectors;

            if (placesPerSector <= 0)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }

            this.places = placesPerSector;
        }
    }
}