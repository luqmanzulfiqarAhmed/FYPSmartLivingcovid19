using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class MarriageHall
    {
        
        
        [BsonElement("menues")]
        public List<Menue> menues ;
        [BsonElement("Halls")]
        public List<Hall> halls ;
        
        public MarriageHall(){}
    }
}
