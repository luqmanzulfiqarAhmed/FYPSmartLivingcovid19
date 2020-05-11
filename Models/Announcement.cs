using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Announcement
    {
        public Announcement() { }

        [BsonElement("anouncementId")]
        public string anouncementId { get; set; }


        [BsonElement("societyId")]
        public string societyId { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("submissionDateTime")]
        public string submissionDateTime { get; set; }

        [BsonElement("expireDate")]
        public string expireDate { get; set; }


        [BsonElement("IPAddress")]
        public string IPAddress { get; set; }

        [BsonElement("subject")]
        public string subject { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

    }
}
