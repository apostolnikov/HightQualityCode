namespace VehicleParkSystem.Interfaces
{
    using System;
    using VehicleParkSystem.Vehicles;

    public interface IVehiclePark
    {
        /// <summary>
        /// Adds a car with the specified properties to the vehicle park system.
        /// </summary>
        /// <param name="car">car type</param>
        /// <param name="sector">the parking sector</param>
        /// <param name="placeNumber">the sector place number</param>
        /// <param name="startTime">shows when the car has been added to the park system</param>
        /// <returns>returns a succes message (Car parked successfully at place{place number}) else return an error message "The place (place number) is occupied"</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a motorbike with the specified properties to the vehicle park system.
        /// </summary>
        /// <param name="motorbike">motorbike type</param>
        /// <param name="sector">the parking sector</param>
        /// <param name="placeNumber">the sector place number</param>
        /// <param name="startTime">shows when the motorbike has been added to the park system</param>
        /// <returns>returns a succes message (Motorbike parked successfully at place{place number}) else return an error message "The place (place number) is occupied"</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a truck with the specified properties to the vehicle park system.
        /// </summary>
        /// <param name="motorbike">truck type</param>
        /// <param name="sector">the parking sector</param>
        /// <param name="placeNumber">the sector place number</param>
        /// <param name="startTime">shows when the truck has been added to the park system</param>
        /// <returns>returns a succes message (Truck parked successfully at place{place number}) else return an error message "The place (place number) is occupied"</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Exit a vehicle from the park system
        /// </summary>
        /// <param name="licensePlate">the license plate of the vehicle</param>
        /// <param name="endTime">shows when the vehicle has been removed from the park system</param>
        /// <param name="amountPaid">the paid amounth for the parking slot</param>
        /// <returns></returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// get the current status from the vehicle park
        /// </summary>
        /// <returns>return a status message for the full or empty sectors</returns>
        string GetStatus();

        /// <summary>
        /// find vehicle from the parking system using license plate
        /// </summary>
        /// <param name="licensePlate">license plate used for finding the vehicle</param>
        /// <returns>Returns a success message ("{Vehicle type} [{license plate}], owned by {owner name}") an error message ("There is no vehicle with {license plate} in the park")
        /// if the ticket already exists.</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// find vehicle by its owner
        /// </summary>
        /// <param name="owner">owner name of the vehicle</param>
        /// <returns>Returns a success message ("{Vehicle type} [{license plate}], owned by {owner name}") an error message ("There is no vehicle by {owners name}")
        /// if the ticket already exists.</returns>
        string FindVehiclesByOwner(string owner);
    }
}
