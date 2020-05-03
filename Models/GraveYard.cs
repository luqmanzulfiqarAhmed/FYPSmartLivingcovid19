using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class GraveYard
    {
        [BsonElement("pricePerGrave")]
        public String pricePerGrave;        
        [BsonElement("vacantGraves")]
        public String vacantGraves;
        public GraveYard (){}
    }
}
