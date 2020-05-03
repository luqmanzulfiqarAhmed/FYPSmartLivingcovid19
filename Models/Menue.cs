using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Menue
    {

        [BsonElement("priceOfMenue")]
        public String priceOfMenue;
        [BsonElement("category")]
        public String category;
        [BsonElement("items")]
        public List<Item> items;
        public Menue(){}
    }
}
