using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Resident
    {
        public Resident() { }

        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("propertyId")]
        public string propertyId;
        [BsonElement("residentEmaill")]
        public string residentEmaill;//is the resident id
        [BsonElement("residentFirstName")]
        public string residentFirstName;
        [BsonElement("residentLastName")]
        public string residentLastName;
        [BsonElement("residentPassword")]
        public string residentPassword;
        [BsonElement("residentPhoneNumber")]
        public string residentPhoneNumber;
        [BsonElement("residentAddress")]
        public string residentAddress;
        [BsonElement("residentImage")]
        public string residentImage;//data type will be change
        [BsonElement("residentCnic")]
        public string residentCnic;
        [BsonElement("residentType")]
        public string residentType;//commercial or house

    }
}
