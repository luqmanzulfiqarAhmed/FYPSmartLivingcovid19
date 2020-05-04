using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Shop
    {
        public Shop() { }
        [BsonElement("shopMenues")]
        public List<Menue> shopMenues;

    }
}
