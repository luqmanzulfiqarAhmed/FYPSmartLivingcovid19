using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Models
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        
        
        [BsonElement("societyId")]
        public string societyId;
        [BsonElement("employeeEmail")]
        public string employeeEmail;

        [BsonElement("employeePassword")]
        public string employeePassword;

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

        [BsonElement("employeeDesignation")]
        public string employeeDesignation;
        [BsonElement("isAvailable")]
        public Boolean isAvailable=false;
        [BsonElement("employeeRateing")]
        public string employeeRateing;
        public Employee() { }
    }
}
