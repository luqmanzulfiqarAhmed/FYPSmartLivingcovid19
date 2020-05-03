using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageBill 
    {
        [BsonElement("billId")]
            public string billId { get; set; }
        [BsonElement("societyId")]
            public string societyId { get; set; }

        [BsonElement("propertyId")]
            public string propertyId { get; set; }
        [BsonElement("residentEmail")]
            public string residentEmail { get; set; }
        [BsonElement("issueDate")]
            public string issueDate { get; set; }
        [BsonElement("dueDate")]
            public string dueDate { get; set; }
        [BsonElement("MeterNumber")]
            public string MeterNumber { get; set; }
        [BsonElement("gallons")]
          public string gallons { get; set; }
        [BsonElement("billType")]

            public string billType { get; set; }
        [BsonElement("unitsConsumed")]
            public string unitsConsumed { get; set; }
        [BsonElement("unitPrice")]
            public string unitPrice { get; set; }
        [BsonElement("billAmount")]
            public string billAmount { get; set; }
        public ManageBill()
        {
        }



        public void calculateBill()
        {


        }

    }


}