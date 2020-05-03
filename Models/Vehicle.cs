using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("vehicleId")]
        public string vehicleId;
        [BsonElement("maxPassengers")]
        public string maxPassengers;
        [BsonElement("vehicleDiscription")]//Ambulance,firebrigade
        public string vehicleDiscription;

        [BsonElement("employeeEmail")]
        public string employeeEmail;
        [BsonElement("employeeFirstName")]
        public string employeeFirstName;
        [BsonElement("employeeLastName")]
        public string employeeLastName;
        [BsonElement("employeePhoneNumber")]
        public string employeePhoneNumber;
        [BsonElement("employeeCnic")]
        public string employeeCnic;
        [BsonElement("employeeImage")]
        public string employeeImage;//data type will be change
        [BsonElement("isAvailable")]
        public Boolean isAvailable = false;
        [BsonElement("currentLocation")]
        public Location currentLocation;

        public class Location
        {
            public Location() { }
            public string lat, lng;

        }
    }
}
