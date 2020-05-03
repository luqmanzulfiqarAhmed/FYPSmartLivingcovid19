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
    public class MaintainanceTaskResponseRepositry
    {
        private MongoDbContext dbContext = null;
        public MaintainanceTaskResponseRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<MaintainanceTaskResponse>("MaintainanceTaskResponse");//use singletone object to get database 
            //and call that database to get collection of MaintainanceTaskResponse
        }
        private readonly IMongoCollection<MaintainanceTaskResponse> collection;

        public async Task<object> retriveAllData()
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
            MaintainanceTaskResponse MaintainanceTaskResponse = (MaintainanceTaskResponse)obj;

            await collection.InsertOneAsync((MaintainanceTaskResponse)MaintainanceTaskResponse);
            return true;

        }
        public async Task<object> getEmployees(string employeeDepartment)
        {

            IMongoCollection<Employee> employeeCollection = dbContext.getDataBase().GetCollection<Employee>("Employee");
            var employees = Builders<Employee>.Filter.Eq("employeeDepartment", employeeDepartment);
            var available = Builders<Employee>.Filter.Eq("isAvailable", true);
            var combineFilters = Builders<Employee>.Filter.And(employees, available);
            return await employeeCollection.Find(combineFilters).ToListAsync();

        }

        public async Task<object> retrieve(string pId)
        {
            var MaintainanceTaskResponse = Builders<MaintainanceTaskResponse>.Filter.Eq("MaintainanceTaskResponseId", pId);
            return await collection.Find(MaintainanceTaskResponse).ToListAsync();
        }
        public async Task<object> retrieveTask(string employeeEmail)
        {

            var result = collection.Aggregate()
                .Match(c => c.taskStatus.Equals("pending"))
                .Match(c => c.workingEmployee.employeeEmail== employeeEmail)
              .Project(c => new MaintainanceTaskResponse()).FirstAsync();

            return await result;
        }
        public async Task<object> retrieveAll(string MaintainanceTaskResponseId)
        {
            var MaintainanceTaskResponse = Builders<MaintainanceTaskResponse>.Filter.Eq("MaintainanceTaskResponseId", MaintainanceTaskResponseId);
            return await collection.Find(MaintainanceTaskResponse).ToListAsync();
        }

        public async Task<object> update(string id, object MaintainanceTaskResponse)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.taskId == id, (MaintainanceTaskResponse)MaintainanceTaskResponse);
            return true;
        }
    }
}
