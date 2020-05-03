using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Property
    {
        public Property(){}
        [BsonElement("societyId")]
        public String societyId;
        [BsonElement("propertyId")]
        public String propertyId;
        [BsonElement("PropertyType")]
        public String PropertyType;
        [BsonElement("PropertyArea")]

        public String PropertyArea;
        [BsonElement("PropertyStatus")]
        public String PropertyStatus;
        [BsonElement("PropertyImage")]
        public String PropertyImage;
        [BsonElement("PropertyAddress")]

        public String PropertyAddress;
        [BsonElement("PropertyName")]
        public String PropertyName;
        [BsonElement("PropertyDiscription")]
        public String PropertyDiscription;
        [BsonElement("lng")]
        public String lng;
        [BsonElement("lat")]
        public String lat;


        [BsonElement("Commercial")] 
        public Commercial Commercial;

        public Commercial getCommercial(){

            return this.Commercial;
        }
        public void setCommercial(Commercial Commercial){

             this.Commercial = Commercial;
        }
        
    }
}
