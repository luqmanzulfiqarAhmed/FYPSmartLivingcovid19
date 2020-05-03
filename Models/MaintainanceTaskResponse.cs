using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class MaintainanceTaskResponse:TaskResponse
    {
        public MaintainanceTaskResponse() { }
        [BsonElement("workingEmployee")]
        public Employee workingEmployee;// employee for simple task
        [BsonElement("isApproved")]
        public Boolean isApproved;// employee for simple task
    }
}
