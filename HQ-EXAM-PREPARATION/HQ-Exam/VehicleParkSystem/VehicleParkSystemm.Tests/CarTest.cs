namespace VehicleParkSystemm.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using VehicleParkSystem.Interfaces;

    [TestClass]
    public class CarTest
    {
        private IVehiclePark park;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.park = new VehicleParkSystem();
        }

        [TestMethod]
        public void Test_InsertCar_ShouldInsertTheCar()
        {
            string message = this.park.InsertCar(
                type: "car",
                sector: 1,
                place: 5,
                licensePlate: "CA1001HH",
                owner: "Jay Margareta",
                hours: 1);

            Assert.AreEqual("Car parked successfully at place (1,5)", message);
            
        }
       
        [TestMethod]
        public void Test_ExitCar_ShouldRemoveTheCarFromThePark()
        {
            this.park.InsertCar(
                type: "car",
                sector: 1,
                place: 5,
                licensePlate: "CA1001HH",
                owner: "Jay Margareta",
                hours: 1);

            string message = this.park.ExitVehicle("CA5555AH",new DateTime(2015, 05, 04), 100m);

            Assert.AreEqual("Car parked successfully at place (1,5)", message);
        }

        [TestMethod]
        public void Test_FindCar_ShouldFindTheCarByLicencePlate()
        {
            this.park.InsertCar(
                type: "car",
                sector: 1,
                place: 5,
                licensePlate: "CA1001HH",
                owner: "Jay Margareta",
                hours: 1);

            string message = this.park.FindVehicle("CA1001HH");

            Assert.AreEqual("Car [CA1001HH], owned by Jay Margareta Parked at (1,5)", message);
           
        }

        [TestMethod]
        public void Test_FindCar_ShouldFindTheCarByOwner()
        {
            this.park.InsertCar(
                type: "car",
                sector: 1,
                place: 5,
                licensePlate: "CA1001HH",
                owner: "Jay Margareta",
                hours: 1);

            string message = this.park.FindVehicle("Jay Margareta");

            Assert.AreEqual("Car [CA1001HH], owned by Jay Margareta Parked at (1,5)", message);

        }
    }
}
