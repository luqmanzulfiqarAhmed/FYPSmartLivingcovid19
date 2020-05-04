using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class Service
    {
        public Service() { }

        [BsonElement("graveBooking")]
        public GraveBooking graveBooking;


        [BsonElement("graveBookingIsAvail")]
        public bool graveBookingIsAvail;

        [BsonElement("hallReservation")]
        public MarriageHallReservation hallReservation;

        
        [BsonElement("hallReservationIsAvail")]
        public bool hallReservationIsAvail;

        [BsonElement("goodsOrdering")]
        public GoodsOrdering goodsOrdering;
        [BsonElement("goodsOrderingIsAvail")]
        public bool goodsOrderingIsAvail;
        [BsonElement("transport")]
        public Transport transport;
        [BsonElement("transportIsAvail")]
        public bool transportIsAvail;
        [BsonElement("emergencyTaskResponse")]
        public EmergencyTaskResponse emergencyTaskResponse;
        
        [BsonElement("emergencyTaskResponseIsAvail")]
        public bool emergencyTaskResponseIsAvail;
        [BsonElement("maintainanceTaskResponse")]
        public MaintainanceTaskResponse maintainanceTaskResponse;
        [BsonElement("maintainanceTaskResponseIsAvail")]
        public bool maintainanceTaskResponseIsAvail;
        [BsonElement("complain")]
        public Complain complain;
        [BsonElement("complainIsAvail")]
        public bool complainIsAvail;
        [BsonElement("announcement")]
        public Announcement announcement;
        [BsonElement("announcementIsAvail")]
        public bool announcementIsAvail;


    }
}
