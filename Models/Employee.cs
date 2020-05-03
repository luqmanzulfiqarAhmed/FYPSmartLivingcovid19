using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    public class Employee
    {
        public Employee() { }
        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("employeeEmail")]
        public string employeeEmail;
        [BsonElement("employeeFirstName")]
        public string employeeFirstName;
        [BsonElement("employeeLastName")]
        public string employeeLastName;
        [BsonElement("employeePhoneNumber")]
        public string employeePhoneNumber;
        [BsonElement("employeeCnic")]
        public string employeeCnic;
        [BsonElement("employeeAddress")]
        public string employeeAddress;
        [BsonElement("employeeImage")]
        public string employeeImage;//data type will be change
        [BsonElement("employeeDepartment")]
        public string employeeDepartment;
        [BsonElement("isAvailable")]
        public Boolean isAvailable=false;
        [BsonElement("employeeRateing")]
        public string employeeRateing;
        
    }
}
