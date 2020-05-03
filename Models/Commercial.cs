using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Commercial
    {
        public Commercial() { }


        [BsonElement("open")]
        public String open;
        [BsonElement("close")]
        public String close;
        [BsonElement("rateing")]
        public String rateing;
        [BsonElement("maxCapacity")]
        public String maxCapacity;

        [BsonElement("graveYard")]
        public GraveYard graveYard;
        [BsonElement("marriageHall")]
        public MarriageHall marriageHall;
        [BsonElement("mosque")]
        public Mosque mosque;
        [BsonElement("shop")]
        public Shop shop;
        
    }
}
