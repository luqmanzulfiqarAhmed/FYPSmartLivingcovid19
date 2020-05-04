using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class TaskResponse
    {
        public TaskResponse() { }

        [BsonElement("societyId")]
        public string societyID { get; set; }
        
        [BsonElement("residentEmail")]
        public string residentEmail;
        [BsonElement("residentName")]
        public string residentName;
        [BsonElement("residentPhoneNumber")]
        public string residentPhoneNumber;
        [BsonElement("residentAddress")]
        public string residentAddress;

        [BsonElement("image")]
        public string image;//data type will be change
        [BsonElement("taskDiscription")]
        public string taskDiscription;
        [BsonElement("taskDateTime")]
        public string taskDateTime;
        [BsonElement("taskStatus")]
        public string taskStatus;//pending, resolved
        [BsonElement("taskType")]
        public string taskType;//ambulance or electrician or firebrigade
        [BsonElement("taskLocation")]
        public Location taskLocation;
        [BsonElement("taskId")]
        public string taskId;//composse of taskLocation+date+time
         
        
        public class Location
        {
            public Location() { }
            public string lat, lng;

        }

    }
}
