using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Stops
    {
        public Stops() { }
        [BsonElement("stopName")]
        public string stopName;        
        [BsonElement("arivalTime")]
        public string arivalTime;
        [BsonElement("departureTime")]
        public string departureTime;

        [BsonElement("location")]
        public Location location;

        
        public class Location {
            public Location() { }
            public string lat, lng;

        }
    }
}
