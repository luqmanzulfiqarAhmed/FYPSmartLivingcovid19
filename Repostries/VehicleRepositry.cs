
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartLiving.Models;
using smartLiving.MongoDb;

using Newtonsoft.Json;
namespace smartLiving.Repostries

{
    public class VehicleRepositry
    {

        private MongoDbContext dbContext = null;
        public VehicleRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Vehicle>("Vehicle");//use singletone object to get database 
            //and call that database to get collection of Vehicle
        }
        private readonly IMongoCollection<Vehicle> collection;

          
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {           
             Vehicle vehicle = (Vehicle)obj;                                               
                await collection.InsertOneAsync((Vehicle)vehicle);
                return true;

        }

        public async Task<object> retrieve(string societyId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("societyId", societyId);            
            return  await collection.Find(vehicle).ToListAsync();
        }

        public async Task<object> retrieveAll(string vehicleId, string societyId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("societyId", societyId);
            var society = Builders<Vehicle>.Filter.Eq("vehicleId", vehicleId);
            var combineFilters = Builders<Vehicle>.Filter.And(vehicle, society);
            return await collection.Find(combineFilters).SingleAsync();
            
        }

public async Task<object> retrieveByType( string societyId,string vType)
        {
            var society = Builders<Vehicle>.Filter.Eq("societyId", societyId);
            var vehicle = Builders<Vehicle>.Filter.Eq("vehicleDiscription", vType);
            var combineFilters = Builders<Vehicle>.Filter.And(vehicle, society);
            return await collection.Find(combineFilters).ToListAsync();
            
        }
        public async Task<object> retrieveByEmail( string societyId,string email)
        {
            var society = Builders<Vehicle>.Filter.Eq("societyId", societyId);
            var emailData = Builders<Vehicle>.Filter.Eq("employeeEmail", email);
            var combineFilters = Builders<Vehicle>.Filter.And( society,emailData);
            return await collection.Find(combineFilters).SingleOrDefaultAsync();
            
        }
        public async Task<object> update(string id, object vehicle)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.vehicleId == id, (Vehicle)vehicle);
            return true;
        }
    }
}
