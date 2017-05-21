namespace VehicleParkSystem.Vehicles
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Utilities;

    public class Moto : IVehicle
    {
        private string licensePlate;
        private string person;
        private decimal regularRate;
        private decimal overTimeRate;
        private int reversedHours;

        public Moto(string licensePlate, string person, int hh)
        {
            this.RegularRate = MotoRegularRate;
            this.OvertimeRate = MotoOvertimeRate;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                Validation.ForLicensePlateMatch(value);
                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.person;
            }

            set
            {
                Validation.ForEmptyOrNullOwner(value);
                this.person = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                Validation.ForNegativeRegularRate(value);
                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overTimeRate;
            }

            set
            {
                Validation.ForNegativeOvertimeRate(value);
                this.overTimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reversedHours;
            }

            set
            {
                Validation.ForPositiveReversedHours(value);
                this.reversedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{2}], owned by {1}", GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
