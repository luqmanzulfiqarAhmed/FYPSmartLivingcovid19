using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Hall
    {
        
        [BsonElement("hallId")]
        public string hallId ;

        [BsonElement("hallName")]
        public string hallName ;

        [BsonElement("hallMaxCapacity")]
        public string hallMaxCapacity ;

        
        public Hall(){}
    }
}
