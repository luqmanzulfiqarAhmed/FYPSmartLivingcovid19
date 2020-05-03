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
    public class EmergencyTaskResponseRepositry
    {
        private MongoDbContext dbContext = null;
        public EmergencyTaskResponseRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<EmergencyTaskResponse>("EmergencyTaskResponse");//use singletone object to get database 
            //and call that database to get collection of EmergencyTaskResponse
        }
        private readonly IMongoCollection<EmergencyTaskResponse> collection;

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
            EmergencyTaskResponse EmergencyTaskResponse = (EmergencyTaskResponse)obj;

            await collection.InsertOneAsync((EmergencyTaskResponse)EmergencyTaskResponse);
            return true;

        }

        public async Task<object> retrieveTask(string vehicleId)
        {            

            var result = collection.Aggregate()
                .Match(c => c.taskStatus.Equals("pending"))
                .Match(c => c.emergencyVehicle.vehicleId == vehicleId)
              .Project(c => new EmergencyTaskResponse()).FirstAsync();
            
            return await result;
        }
        
        public async Task<object> retrieveAll(string societyId)
        {
            var EmergencyTaskResponse = Builders<EmergencyTaskResponse>.Filter.Eq("societyId", societyId);
            return await collection.Find(EmergencyTaskResponse).ToListAsync();
        }
        
        public async Task<object> getVehichles(string vehicleDiscription)
        {

            IMongoCollection<Vehicle> vehicleCollection = dbContext.getDataBase().GetCollection<Vehicle>("Vehicle");
            var vehicle = Builders<Vehicle>.Filter.Eq("vehicleDiscription", vehicleDiscription);            
            var available = Builders<Vehicle>.Filter.Eq("isAvailable", true);
            var combineFilters = Builders<Vehicle>.Filter.And(vehicle, available);
            return await vehicleCollection.Find(combineFilters).ToListAsync();

        }
        public async Task<object> update(string id, object EmergencyTaskResponse)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.taskId == id, (EmergencyTaskResponse)EmergencyTaskResponse);
            return true;
        }
    }
}
