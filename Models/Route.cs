using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Route
    {
        public Route() { }
        [BsonElement("routeId")]
        public string routeId;
        [BsonElement("routeName")]
        public string routeName;
        [BsonElement("busStops")]
        public List<Stops> busStops;

    }
}
