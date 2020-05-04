using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class MarriageHallReservation
    {
        public MarriageHallReservation() { }

        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("hallReservationId")]
        public string hallReservationId;
        [BsonElement("residentEmail")]
        public string residentEmail;
        [BsonElement("residentName")]
        public string residentName;
        [BsonElement("residentPhoneNumber")]
        public string residentPhoneNumber;
        [BsonElement("residentAddress")]
        public string residentAddress;
        [BsonElement("marriageHall")]
        public Property marriageHall;
        [BsonElement("reservationStatus")]
        public string reservationStatus;
        [BsonElement("eventType")]
        public string eventType;
        [BsonElement("date")]
        public string date;
        [BsonElement("totalBill")]
        public string totalBill;
        [BsonElement("numberOfGuessts")]
        public string numberOfGuessts;
        [BsonElement("timeSlot")]
        public string timeSlot;//morning evening noon
        [BsonElement("selectedMenue")]
        public Menue selectedMenue;
    }
}
