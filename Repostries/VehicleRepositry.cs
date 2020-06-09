
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

        public async Task<object> retrieve(string vehicleId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("vehicleId", vehicleId);            
            return  await collection.Find(vehicle).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("societyId", societyId);
            return await collection.Find(vehicle).ToListAsync();
        }

        public async Task<object> update(string id, object vehicle)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.vehicleId == id, (Vehicle)vehicle);
            return true;
        }
    }
}
