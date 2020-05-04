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
        [BsonElement("location")]
        public Location location;
        [BsonElement("arivalTime")]
        public Location arivalTime;
        [BsonElement("departureTime")]
        public Location departureTime;
        public class Location {
            public Location() { }
            public string lat, lng;

        }
    }
}
