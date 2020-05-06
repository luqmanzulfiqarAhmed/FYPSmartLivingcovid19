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
    public class SocietyRepositry 
    {
        private MongoDbContext dbContext = null;
        public SocietyRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Society>("Society");//use singletone object to get database 
            //and call that database to get collection of Society
        }
        private readonly IMongoCollection<Society> collection;

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
            Society Society = (Society)obj;

            await collection.InsertOneAsync((Society)Society);
            return true;

        }

        public async Task<object> retrieve(string pId)
        {
            var society = Builders<Society>.Filter.Eq("societyId", pId);
            return await collection.Find(society).SingleAsync();

            
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var Society = Builders<Society>.Filter.Eq("societyId", societyId);
            return await collection.Find(Society).ToListAsync();
        }

        public async Task<object> update(string id, object Society)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.societyId == id, (Society)Society);
            return true;
        }
    }
}
