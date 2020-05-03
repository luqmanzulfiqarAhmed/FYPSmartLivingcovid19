using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
 

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Admin
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        // public string Id { get; set; }        //this is internal id of mongodb we have our own 
        // i.e adminId we store unique id by using find before registring any admin 

        
       //will act as admin id
      [BsonElement("adminEmail")]
        public string adminEmail { get; set; }

       [BsonElement("adminFirstName")]
        public string adminFirstName { get; set; }
      
      [BsonElement("adminLastName")]
        public string adminLastName { get; set; }
      
      [BsonElement("adminPassword")]
        public string adminPassword { get; set; }
      
      [BsonElement("adminCnic")]
        public string adminCnic { get; set; }

      [BsonElement("adminPhoneNo")]
        public string adminPhoneNo { get; set; }
      
      [BsonElement("admindateofBirth")]
        public string admindateofBirth { get; set; }
      
      [BsonElement("societyId")]
        public string societyID { get; set; }


        public Admin()
        {

        }
    }
}
