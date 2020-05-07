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
    public class ResidentRepositry 
    {
        private MongoDbContext dbContext = null;
        public ResidentRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Resident>("Resident");//use singletone object to get database 
            //and call that database to get collection of Resident
        }
        private readonly IMongoCollection<Resident> collection;

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
            Resident Resident = (Resident)obj;

            await collection.InsertOneAsync((Resident)Resident);
            return true;

        }

        public async Task<object> retrieveByEmail(string email)
        {
            var Resident = Builders<Resident>.Filter.Eq("residentEmaill", email);
            return await collection.Find(Resident).SingleAsync();
        }
        public async Task<object> retrieveList(string email)
        {
            var Resident = Builders<Resident>.Filter.Eq("residentEmaill", email);
            return await collection.Find(Resident).ToListAsync();
        }
        public async Task<object> retrieveBySidPid(string pId,string sId)
        {
            var bySId = Builders<Resident>.Filter.Eq("societyId", sId);
            var byPId = Builders<Resident>.Filter.Eq("propertyId", pId);
            var combineFilters = Builders<Resident>.Filter.And(bySId, byPId);
            return await collection.Find(combineFilters).SingleAsync();
        }
        public async Task<object> retrieveBySidPidEmail(string pId,string sId,string email)
        {
            var bySId = Builders<Resident>.Filter.Eq("societyId", sId);
            var byPId = Builders<Resident>.Filter.Eq("propertyId", pId);
            var Resident = Builders<Resident>.Filter.Eq("residentEmaill", email);
            var combineFilters = Builders<Resident>.Filter.And(bySId, byPId,Resident);
            return await collection.Find(combineFilters).SingleAsync();
        }
        public async Task<object> retrieveBySid(string societyId)
        {
            var Resident = Builders<Resident>.Filter.Eq("societyId", societyId);
            return await collection.Find(Resident).ToListAsync();
        }
public async Task<object> retrieveAll(string societyId)
        {
            var Society = Builders<Resident>.Filter.Eq("societyId", societyId);
            return await collection.Find(Society).ToListAsync();
        }
        public async Task<bool> update(string id, object Resident)
        {
            try{
            await collection.ReplaceOneAsync(ZZ => ZZ.residentEmaill == id, (Resident)Resident);
            return true;
            }catch(Exception ex){
                   return false; 

            }
            
        }
    
    }
}
