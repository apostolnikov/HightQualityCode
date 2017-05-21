namespace VehicleParkSystem.Utilities
{
    using System;
    using System.Text.RegularExpressions;

    public static class Validation
    {
        public static void ForLicensePlateMatch(string licensePlate)
        {
            if (!Regex.IsMatch(licensePlate, @"^[A-Z]{1}\d{3}[A-Z]{2,}$"))
            {
                throw new ArgumentException("The license plate number is invalid.");
            } 
        }

        public static void ForEmptyOrNullOwner(string owner)
        {
            if (owner == null && owner == string.Empty)
            {
                throw new InvalidCastException("The owner is required.");
            } 
        }

        public static void ForNegativeRegularRate(decimal regularRate)
        {
            if (regularRate < 0)
            {
                throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
            } 
        }

        public static void ForNegativeOvertimeRate(decimal overtimeRate)
        {
            if (overtimeRate < 0)
            {
                throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative.")); 
            }
        }

        public static void ForPositiveReversedHours(int reversedHours)
        {
            if (reversedHours <= 0)
            {
                throw new ArgumentException("The reserved hours must be positive.");
            } 
        }
    }
}
