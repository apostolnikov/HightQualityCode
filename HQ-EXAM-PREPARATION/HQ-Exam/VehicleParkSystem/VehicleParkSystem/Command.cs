namespace VehicleParkSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.CodeDom;
    using System.ComponentModel;
    using System.Configuration;
    using System.Xml;
    using v = vp_system_himineu.VehicleParkSystem;
    using System.Web;
    using System.Net;
    using System.Reflection;
    using Microsoft.CSharp.RuntimeBinder;
    using MS.Internal.Xml.XPath;
    using System.Security.Authentication;
    using System.Security.Claims;
    using System.IO.IsolatedStorage;
    using System.IO.Ports;
    using vp_system_himineu;
    using System.Web.Script.Serialization;
    using VehicleParkSystem.Interfaces;

    class Execute
    {

        public class Command : ICommand
        {
            public string name { get; set; }
            public IDictionary<string, string> parameters { get; set; }

            public Command(string str)
            {
                name = str.Substring(0, str.IndexOf(' ')); 
                parameters = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
            }
        }

        VehicleParkSystem VehiclePark { get; set; }
        public string (ICommand c)
        {
            if (c.name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }
            switch (c.name)
            {
                case "SetupPark":
                    VehiclePark =new VehiclePark(c.Parameters["sectors"]+1,c.Parameters["placesPerSector"]);
                    return "Vehicle park created";
                case "Рark":
                    switch (c.parameters["type"])
                    {
                        case "car": 
                            return VehiclePark.InsertCar(new VehiclePark3.Carro(c.parameters["licensePlate"], 
                                c.parameters["owner"], 
                                int.Parse(c.parameters["hours"])), 
                                int.Parse(c.parameters["sector"]), 
                                int.Parse(c.parameters["place"]), 
                                DateTime.Parse(c.parameters["time"], 
                                null, 
                                System.Globalization.DateTimeStyles.RoundtripKind));//why round trip kind??

                        case "motorbike": 
                            return VehiclePark.InsertMotorbike(new VehiclePark3.Moto(c.parameters["licensePlate"], 
                                c.parameters["owner"], 
                                int.Parse(c.parameters["hours"])), 
                                int.Parse(c.parameters["sector"]), 
                                int.Parse(c.parameters["place"]), 
                                DateTime.Parse(c.parameters["time"], 
                                null, 
                                System.Globalization.DateTimeStyles.RoundtripKind));//stack overflow says this

                        case "truck": 
                            return VehiclePark.InsertTruck(new VehiclePark3.Caminhão(c.parameters["licensePlate"], 
                                c.parameters["owner"], 
                                int.Parse(c.parameters["hours"])), 
                                int.Parse(c.parameters["sector"]), 
                                int.Parse(c.parameters["place"]), 
                                DateTime.Parse(c.parameters["time"], 
                                null, 
                                System.Globalization.DateTimeStyles.RoundtripKind));//I wanna know
                    }
                    break;

            }
        }
    }
}



























                case "Exit": return VehiclePark.ExitVehicle(c.parâmetros["licensePlate"], DateTime.Parse(c.parâmetros["time"], null, System.Globalization.DateTimeStyles.RoundtripKind), decimal.Parse(c.parâmetros["money"]));
                case "Status": return VehiclePark.GetStatus();
                case "FindVehicle": return VehiclePark.FindVehicle(c.parâmetros["licensePlate"]);
                case "VehiclesByOwner": return VehiclePark.FindVehiclesByOwner(c.parâmetros["owner"]);
                default: throw new IndexOutOfRangeException("Invalid command.");




            }



            return "";


        }


    }

}















