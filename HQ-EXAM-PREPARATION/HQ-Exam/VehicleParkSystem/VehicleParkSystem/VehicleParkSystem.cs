namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Vehicles;
    using Wintellect.PowerCollections;

    public class VehicleParkSystem : IVehiclePark
    {
        private Layout layout;
        private Data data;

        public VehicleParkSystem(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new Data(numberOfSectors);
        }

        public string InsertCar(Car car, int s, int p, DateTime t)
        {
            if (s > this.layout.sectors)
            {
                return string.Format("There is no sector {0} in the park", s);
            }

            if (p > this.layout.places)
            {
                return string.Format("There is no place {0} in sector {1}", p, s);
            }

            if (this.data.ParkPlace.ContainsKey(string.Format("({0},{1})", s, p)))
            {
                return string.Format("The place ({0},{1}) is occupied", s, p);
            }

            if (this.data.LicensePlate.ContainsKey(car.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", carro.LicensePlate);
            }

            this.data.AllCarsInPark[car] = string.Format("({0},{1})", s, p);
            this.data.ParkPlace[string.Format("({0},{1})", s, p)] = car;
            this.data.LicensePlate[car.LicensePlate] = car;
            this.data.D[car] = t;
            this.data.Owner[car.Owner].Add(car);
            this.data.count[s - 1]--;

            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, s, p);
        }

        public string InsertMotorbike(Motorbike motorbike, int s, int p, DateTime t)
        {
            if (s > this.layout.sectors)
            {
                return string.Format("There is no sector {0} in the park", s);
            }

            if (p > this.layout.places)
            {
                return string.Format("There is no place {0} in sector {1}", p, s);
            }

            if (this.data.ParkPlace.ContainsKey(string.Format("({0},{1})", s, p)))
            {
                return string.Format("The place ({0},{1}) is occupied", s, p);
            }

            if (this.data.LicensePlate.ContainsKey(motorbike.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", motorbike.LicensePlate);
            }

            this.data.AllCarsInPark[motorbike] = string.Format("({0},{1})", s, p);
            this.data.ParkPlace[string.Format("({0},{1})", s, p)] = motorbike;
            this.data.LicensePlate[motorbike.LicensePlate] = motorbike;
            this.data.D[motorbike] = t;
            this.data.Owner[motorbike.Owner].Add(motorbike);
            this.data.count[s - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", motorbike.GetType().Name, s, p);
        }

        public string InsertTruck(Truck truck, int s, int p, DateTime t)
        {
            if (s > this.layout.sectors)
            {
                return string.Format("There is no sector {0} in the park", s);
            }

            if (p > this.layout.places)
            {
                return string.Format("There is no place {0} in sector {1}", p, s);
            }

            if (this.data.ParkPlace.ContainsKey(string.Format("({0},{1})", s, p)))
            {
                return string.Format("The place ({0},{1}) is occupied", s, p);
            }

            if (this.data.LicensePlate.ContainsKey(truck.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", truck.LicensePlate);
            }

            this.data.AllCarsInPark[truck] = string.Format("({0},{1})", s, p);
            this.data.ParkPlace[string.Format("({0},{1})", s, p)] = truck;
            this.data.LicensePlate[truck.LicensePlate] = truck;
            this.data.D[truck] = t;
            this.data.Owner[truck.Owner].Add(truck);

            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, s, p);
        }

        public string ExitVehicle(string l_pl, DateTime end, decimal money)
        {
            var vehicle = this.data.LicensePlate.ContainsKey(l_pl) ? this.data.LicensePlate[l_pl] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", l_pl);
            }

            var start = this.data.D[vehicle];
            int endd = (int)Math.Round((end - start).TotalHours);
            var ticket = new StringBuilder();

            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine()
                .AppendFormat("at place {0}", this.data.AllCarsInPark[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", money)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", money - ((vehicle.ReservedHours * vehicle.RegularRate) + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine()
               .Append(new string('*', 20));

            int sector = int.Parse(this.data.AllCarsInPark[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);

            this.data.ParkPlace.Remove(this.data.AllCarsInPark[vehicle]);
            this.data.AllCarsInPark.Remove(vehicle);
            this.data.LicensePlate.Remove(vehicle.LicensePlate);
            this.data.D.Remove(vehicle);
            this.data.Owner.Remove(vehicle.Owner, vehicle);
            this.data.count[sector - 1]--;
        
            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.data.count.Select((sssss, iiiii) => 
                       string.Format("Sector {0}: {1} / {2} ({2}% full)",
                       iiiii + 1,
                       sssss,
                       this.layout.places,
                       Math.Round((double)sssss / this.layout.places * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.data.LicensePlate.ContainsKey(licensePlate) ? this.data.LicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }
            else
            {
                return this.Input(new[] { vehicle });
            }
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.data.ParkPlace.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }
            else
            {
                var found = this.data.ParkPlace.Values.ToList();
                var res = found;
                foreach (var f in found)
                {
                    res = res.Where(v => v.Owner == owner).ToList();
                }

                return string.Join(Environment.NewLine, this.Input(res));
            }
        }

        private string Input(IEnumerable<IVehicle> car)
        {
            return string.Join(
                Environment.NewLine,
                car.Select(vehicle => string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.data.AllCarsInPark[vehicle])));
        }
    }
}