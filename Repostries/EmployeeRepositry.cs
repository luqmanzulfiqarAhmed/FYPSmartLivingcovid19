using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using smartLiving.Models;
using smartLiving.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Repostries
{
    public class EmployeeRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;
        public EmployeeRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Employee>("Employee");//use singletone object to get database 
            //and call that database to get collection of Employee
        }
        private readonly IMongoCollection<Employee> collection;

        public async Task<Object> retriveAllData()
        {
            return await collection.Find(x => true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {
            Employee Employee = (Employee)obj;

            await collection.InsertOneAsync((Employee)Employee);
            return true;

        }

        public async Task<object> retrieve(string pId)
        {
            var Employee = Builders<Employee>.Filter.Eq("employeeEmail", pId);
            return await collection.Find(Employee).ToListAsync();
        }

        public async Task<object> retrieveByDepartment(string sId,string department)
        {
            var society= Builders<Employee>.Filter.Eq("societyId", sId);
            var byDept = Builders<Employee>.Filter.Eq("employeeDepartment", department);
            var combineFilters = Builders<Employee>.Filter.And(society, byDept);
            return await collection.Find(combineFilters).ToListAsync();
        }
public async Task<object> retrieveByEmail(string sId,string email)
        {
            var society= Builders<Employee>.Filter.Eq("societyId", sId);
            var Employee = Builders<Employee>.Filter.Eq("employeeEmail", email);
            var combineFilters = Builders<Employee>.Filter.And(society, Employee);
            return await collection.Find(combineFilters).FirstOrDefaultAsync();
        }
        public async Task<object> retrieveAll(string societyId)
        {
            var Employee = Builders<Employee>.Filter.Eq("societyId", societyId);
            return await collection.Find(Employee).ToListAsync();
        }

        public async Task<object> update(string id, object Employee)
        {
            try{
             await collection.ReplaceOneAsync(ZZ => ZZ.employeeEmail == id, (Employee)Employee);
            return true;
            }catch(Exception ex){
                    return false + ":" + ex.Message;
            }
        }
    
    }
}
