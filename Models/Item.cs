using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Item
    {
        [BsonElement("itemId")]
        public String itemId;
        [BsonElement("itemName")]
        public String itemName;
        [BsonElement("itemDescription")]
        public String itemDescription;        
        [BsonElement("itemPrice")]
        public String itemPrice;
        [BsonElement("itemQuantity")]
        public String itemQuantity;
        public Item(){}
    }
}
