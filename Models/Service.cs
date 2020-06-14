using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Service
    {
        public Service() { }

        [BsonElement("graveBookingIsAvail")]
        public bool graveBookingIsAvail;

        
        [BsonElement("hallReservationIsAvail")]
        public bool hallReservationIsAvail;
        [BsonElement("goodsOrderingIsAvail")]
        public bool goodsOrderingIsAvail;
        [BsonElement("transportIsAvail")]
        public bool transportIsAvail;
        
        [BsonElement("emergencyTaskResponseIsAvail")]
        public bool emergencyTaskResponseIsAvail;
        [BsonElement("maintainanceTaskResponseIsAvail")]
        public bool maintainanceTaskResponseIsAvail;
        [BsonElement("complainIsAvail")]
        public bool complainIsAvail;
        [BsonElement("announcementIsAvail")]
        public bool announcementIsAvail;

        [BsonElement("employeeAvail")]
        public bool employeeAvail;


    }
}
