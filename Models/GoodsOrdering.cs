using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class GoodsOrdering
    {
        public GoodsOrdering() { }

        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("orderId")]
        public string orderId;
        [BsonElement("residentEmail")]
        public string residentEmail;
        [BsonElement("residentName")]
        public string residentName;
        [BsonElement("residentPhoneNumber")]
        public string residentPhoneNumber;
        [BsonElement("residentAddress")]
        public string residentAddress;
        [BsonElement("propertyId")]        
        public String propertyId;
        [BsonElement("dateTime")]
        public string dateTime;
        [BsonElement("orderedItems")]
        public List<Item> orderedItems;
        [BsonElement("totalPrice")]
        public string totalPrice;
    }
}
