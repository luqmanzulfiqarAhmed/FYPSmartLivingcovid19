using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class EmergencyTaskResponse:TaskResponse
    {
        public EmergencyTaskResponse() { }
        [BsonElement("emergencyVehicle")]
        public Vehicle emergencyVehicle;// emergencyVehicle could be ambulance or firebrigade
        
    }
}
