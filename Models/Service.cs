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
        [BsonElement("hallReservation")]
        public MarriageHallReservation hallReservation;
        [BsonElement("goodsOrdering")]
        public GoodsOrdering goodsOrdering;
        [BsonElement("transport")]
        public Transport transport;
        [BsonElement("emergencyTaskResponse")]
        public EmergencyTaskResponse emergencyTaskResponse;
        [BsonElement("maintainanceTaskResponse")]
        public MaintainanceTaskResponse maintainanceTaskResponse;
        [BsonElement("complain")]
        public Complain complain;
        [BsonElement("announcement")]
        public Announcement announcement;


    }
}
