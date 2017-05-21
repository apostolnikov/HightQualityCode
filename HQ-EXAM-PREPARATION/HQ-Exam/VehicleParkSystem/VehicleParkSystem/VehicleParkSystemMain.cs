namespace VehicleParkSystem
{
    using System;
    using System.Globalization;
    using System.Threading;
    using VehicleParkSystem;

    public class VehicleParkSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; 
            var engine = new Engine(); 
            engine.Run();
        }
    }
}