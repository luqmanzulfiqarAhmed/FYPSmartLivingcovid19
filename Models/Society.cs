using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class Society
    {
        public Society() { }

        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("societyName")]
        public string societyName;
        [BsonElement("societyAddress")]
        public string societyAddress;
        [BsonElement("societyCity")]
        public string societyCity;
       
        [BsonElement("societyAdminEmail")]
        public string societyAdminEmail;
        [BsonElement("societyImage")]
        public string societyImage;//data type will be change
        [BsonElement("boundaries")]
        public List<Boundaries> boundaries;
        [BsonElement("services")]
        public Service services;
            


        public class Boundaries {
            public Boundaries() { }
            public string lat,lng;
        }
    }
}
