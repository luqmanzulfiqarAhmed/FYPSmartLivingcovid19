using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class Transport
    {
        public Transport() {}
        [BsonElement("transportId")]
        public string transportId;
        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("vehicle")]
        public Vehicle vehicle;
        [BsonElement("route")]
        public Route route;

    }
}
