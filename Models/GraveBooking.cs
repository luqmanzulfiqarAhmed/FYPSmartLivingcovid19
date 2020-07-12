using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class GraveBooking
    {
        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("graveBookId")]
        public string graveBookId;


        [BsonElement("residentEmail")]
        public string residentEmail;
        [BsonElement("residentName")]
        public string residentName;
        [BsonElement("residentPhoneNumber")]
        public string residentPhoneNumber;

        [BsonElement("propertyId")]
        public String propertyId;
        
        [BsonElement("graveYardName")]
        public String graveyardName;
        
        [BsonElement("graveyardAddress")]
        public String graveyardAddress;


        [BsonElement("graveType")]
        public string graveType;//adult child => (male,female)
        [BsonElement("graveSize")]
        public string graveSize;
        [BsonElement("graveReservationDate")]
        public string graveReservationDate;
        [BsonElement("gravePrice")]
        public string gravePrice;
        [BsonElement("graveRequestStatus")]
        public string graveRequestStatus;//approve or decline

    }
}
