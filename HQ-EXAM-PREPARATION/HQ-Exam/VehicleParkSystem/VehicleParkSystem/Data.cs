namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using VehicleParkSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class Data
    {
        public Data(int numberOfSectors)
        {
            this.AllCarsInPark = new Dictionary<IVehicle, string>();
            this.ParkPlace = new Dictionary<string, IVehicle>();
            this.LicensePlate = new Dictionary<string, IVehicle>();
            this.D = new Dictionary<IVehicle, DateTime>();
            this.Owner = new MultiDictionary<string, IVehicle>(false);
            this.count = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> AllCarsInPark { get; set; }

        public Dictionary<string, IVehicle> ParkPlace { get; set; }

        public Dictionary<string, IVehicle> LicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> D { get; set; }

        public MultiDictionary<string, IVehicle> Owner { get; set; }

        public int[] Count { get; set; }
    }
}